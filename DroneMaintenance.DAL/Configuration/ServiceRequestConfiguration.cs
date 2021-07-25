using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneMaintenance.DAL.Configuration
{
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.Property(s => s.Date).HasDefaultValueSql("GETDATE()");

            builder.HasData
            (
                new ServiceRequest
                {
                    Id = new Guid("38a5dc95-3ff1-4c8f-8041-872a65b41d56"),
                    Description = "description",
                    ServiceType = ServiceType.Diagnostics,
                    ClientId = new Guid("cc38316e-ea63-473b-84fa-1efa00f3b6ce"),
                    DroneId = new Guid("9fffa88b-91c5-42a6-8692-1fd8701fb0e4")
                },
                new ServiceRequest
                {
                    Id = new Guid("fb35b9ce-61c0-4ce3-a309-e742582845af"),
                    ServiceType = ServiceType.RepairWithoutReplacement,
                    ClientId = new Guid("5bf2d2e5-25c7-47d4-b5a0-13068ce73ab2"),
                    DroneId = new Guid("4e02aef0-98d7-430f-bd56-749992687066")
                }
            );
        }
    }
}
