using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DroneMaintenance.DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<ContractSparePart> ContractSpareParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContractSparePart>().HasKey(c => new { c.ContractId, c.SparePartId });
            modelBuilder.Entity<SparePart>().Property(s => s.Price).HasColumnType("money");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
