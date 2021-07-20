using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneMaintenance.DAL.Configuration
{
    public class ContractSparePartConfiguration : IEntityTypeConfiguration<ContractSparePart>
    {
        public void Configure(EntityTypeBuilder<ContractSparePart> builder)
        { 
            builder.HasData
            (
                new ContractSparePart
                {
                    Id = new Guid("9cb1b5b0-4c66-4893-887f-76a259cf26a6"),
                    ContractId = new Guid("50cb65ad-86a1-4abb-afca-fd4b867d7560"),
                    SparePartId = new Guid("193906c8-17a6-4a3c-8eb1-c540cdd6e3fa"),
                    Quantity = 2
                }
            );
        }
    }
}
