using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.User;
using DroneMaintenance.Models.ResponseModels.User;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class UsersService : ServiceBase, IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public UsersService(IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration configuration, 
        IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        
        byte[] GenerateSalt()
        {
            var salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        string GetHashedPassword(string password, byte[] salt) =>
            Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32));

        public async Task<string> RegisterAsync(RegistrationModel registrationModel)
        {
            var userEntity = await _userRepository.GetUserByEmailAsync(registrationModel.Email);
            if (userEntity != null)
            {
                return null;
            }

            var newUserEntity = _mapper.Map<User>(registrationModel);
            var salt = GenerateSalt();
            var stringSalt = Convert.ToBase64String(salt);
            var hashedPassword = GetHashedPassword(registrationModel.Password, salt);

            newUserEntity.Salt = stringSalt;
            newUserEntity.Password = hashedPassword;
            newUserEntity.RoleId = new Guid("f6736344-8a7e-43f4-9a1a-facf460b5f3f");
            await _userRepository.CreateUserAsync(newUserEntity);
            var authenticationModel = _mapper.Map<AuthenticationModel>(registrationModel);

            return await CreateTokenAsync(newUserEntity, authenticationModel);
        }

        public async Task<string> CreateTokenAsync(User userEntity, AuthenticationModel authenticationModel)
        {
            byte[] salt = Convert.FromBase64String(userEntity.Salt);
            var hashedPassword = GetHashedPassword(authenticationModel.Password, salt);
            if (!userEntity.Password.Equals(hashedPassword))
            {
                return null;
            }

            var roleEntity = await _roleRepository.GetRoleByIdAsync(userEntity.RoleId);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", userEntity.Id.ToString()),
                    new Claim(ClaimTypes.Email, userEntity.Email),
                    new Claim(ClaimTypes.Role, roleEntity.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            userEntity.Token = tokenString;
            await _userRepository.UpdateUserAsync(userEntity);

            return tokenString;
        }

        public async Task<string> AuthenticateAsync(AuthenticationModel authenticationModel)
        {
            var userEntity = await _userRepository.GetUserByEmailAsync(authenticationModel.Email);
            if (userEntity == null)
            {
                return null;
            }

            return await CreateTokenAsync(userEntity, authenticationModel);
        }

        public async Task<UserModel> GetUserAsync(Guid id)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(id);
            CheckEntityExistence(id, userEntity, nameof(User));

            return _mapper.Map<UserModel>(userEntity);
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var userEntities = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<List<UserModel>>(userEntities);
        }

        public async Task UpdateToken(Guid id, string token)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(id);
            CheckEntityExistence(id, userEntity, nameof(User));

            userEntity.Token = token;
            await _userRepository.UpdateUserAsync(userEntity);
        }
    }
}
