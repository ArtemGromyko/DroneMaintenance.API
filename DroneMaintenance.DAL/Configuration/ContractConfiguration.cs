using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneMaintenance.DAL.Entities
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasData
            (
                new Contract
                {
                    Id = new Guid("85d636bf-637b-4ab3-9d83-894e829df3d6"),
                    WorkStartDate = new DateTime(2021, 7, 20),
                    ServiceRequestId = new Guid("38a5dc95-3ff1-4c8f-8041-872a65b41d56")
                },
                new Contract
                {
                    Id = new Guid("50cb65ad-86a1-4abb-afca-fd4b867d7560"),
                    WorkStartDate = new DateTime(2021, 7, 20),
                    ServiceRequestId = new Guid("fb35b9ce-61c0-4ce3-a309-e742582845af")
                }
            );
        }
    }
}
