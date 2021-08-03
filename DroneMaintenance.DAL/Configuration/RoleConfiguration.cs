using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneMaintenance.DAL.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasAlternateKey(r => r.Name);

            builder.HasData
            (
                new Role
                {
                    Id = new Guid("865ce3fc-de0d-4372-901d-05e0ba2b8d02"),
                    Name = "admin"
                },
                new Role
                {
                    Id = new Guid("f6736344-8a7e-43f4-9a1a-facf460b5f3f"),
                    Name = "user"
                }
            );
        }
    }
}
