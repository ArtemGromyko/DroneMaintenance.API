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
            builder.Property(s => s.Date).HasColumnType("date");
            builder.Property(s => s.Date).HasDefaultValueSql("GETDATE()");

            builder.HasData
            (
                new ServiceRequest
                {
                    Id = new Guid("38a5dc95-3ff1-4c8f-8041-872a65b41d56"),
                    Description = "description",
                    ServiceType = ServiceType.Diagnostics,
                    UserId = new Guid("bf62c2cd-aa17-47ea-b575-f8d769966fb9"),
                    DroneId = new Guid("9fffa88b-91c5-42a6-8692-1fd8701fb0e4")
                },
                new ServiceRequest
                {
                    Id = new Guid("fb35b9ce-61c0-4ce3-a309-e742582845af"),
                    ServiceType = ServiceType.RepairWithoutReplacement,
                    UserId = new Guid("bf62c2cd-aa17-47ea-b575-f8d769966fb9"),
                    DroneId = new Guid("4e02aef0-98d7-430f-bd56-749992687066")
                }
            );
        }
    }
}
