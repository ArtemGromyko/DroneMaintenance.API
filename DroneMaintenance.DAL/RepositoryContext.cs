using DroneMaintenance.DAL.Configuration;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DroneMaintenance.DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            /*Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<ContractSparePart> ContractSpareParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new DroneConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceRequestConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new SparePartConfiguration());
            modelBuilder.ApplyConfiguration(new ContractSparePartConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
