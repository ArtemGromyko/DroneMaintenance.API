using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneMaintenance.DAL.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData
            (
                new Client
                {
                    Id = new Guid("cc38316e-ea63-473b-84fa-1efa00f3b6ce"),
                    Name = "Tom"
                },
                new Client
                {
                    Id = new Guid("5bf2d2e5-25c7-47d4-b5a0-13068ce73ab2"),
                    Name = "John"
                }
            );
        }
    }
}
