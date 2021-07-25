using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneMaintenance.DAL.Configuration
{
    public class SparePartConfiguration : IEntityTypeConfiguration<SparePart>
    {
        public void Configure(EntityTypeBuilder<SparePart> builder)
        {
            builder.Property(s => s.Price).HasColumnType("money");

            builder.HasData
            (
                new SparePart
                {
                    Id = new Guid("193906c8-17a6-4a3c-8eb1-c540cdd6e3fa"),
                    Name = "sensor",
                    Price = 300
                }
            );
        }
    }
}
