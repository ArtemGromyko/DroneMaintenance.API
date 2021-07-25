using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneMaintenance.DAL.Configuration
{
    public class DroneConfiguration : IEntityTypeConfiguration<Drone>
    {
        public void Configure(EntityTypeBuilder<Drone> builder)
        {
            builder.HasData
            (
                new Drone
                {
                    Id = new Guid("9fffa88b-91c5-42a6-8692-1fd8701fb0e4"),
                    Model = "Mi Drone Mini",
                    Manufacturer = "Xiaomi"
                },
                new Drone
                {
                    Id = new Guid("4e02aef0-98d7-430f-bd56-749992687066"),
                    Model = "DJI Mini 2",
                    Manufacturer = "DJI"
                }
            );
        }
    }
}
