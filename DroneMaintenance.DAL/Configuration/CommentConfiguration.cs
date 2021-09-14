using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneMaintenance.DAL.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Date).HasDefaultValueSql("GETDATE()");

            builder.HasData
            (
                new Comment
                {
                    Id = new Guid("75518431-3035-4a5d-8f91-d8a6e8f8af47"),
                    Header = "Header1",
                    Text = "some text some text some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text",
                    UserId = new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a")
                },
                new Comment
                {
                    Id = new Guid("601ec7d3-b5c9-43c8-8adb-63fdc67bb1bd"),
                    Header = "Header2",
                    Text = "some text some text some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text",
                    UserId = new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a")
                },
                new Comment
                {
                    Id = new Guid("2e296f23-9a12-4991-ad3a-d5ea454d64db"),
                    Header = "Header3",
                    Text = "some text some text some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text",
                    UserId = new Guid("bf62c2cd-aa17-47ea-b575-f8d769966fb9")
                }
            );
        }
    }
}
