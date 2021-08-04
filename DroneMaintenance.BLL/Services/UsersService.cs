using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.Models.RequestModels.User;
using DroneMaintenance.Models.ResponseModels.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public UsersService(IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<string> AuthenticateAsync(AuthenticationModel authenticationModel)
        {
            var userEntity = await _userRepository.GetUserByEmailAndPasswordAsync(authenticationModel.Email, authenticationModel.Password);
            if(userEntity == null)
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
                    new Claim(ClaimTypes.Email, userEntity.Email),
                    new Claim(ClaimTypes.Role, roleEntity.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserModel> GetUserAsync(Guid id)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(id);

            return _mapper.Map<UserModel>(userEntity);
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var userEntities = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<List<UserModel>>(userEntities);
        }
    }
}
