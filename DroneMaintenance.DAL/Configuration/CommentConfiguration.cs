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
                    Id = new Guid("6b147a66-d62e-4252-9add-6cc17cee5d3b"),
                    Header = "Header1",
                    Text = "some text some text some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text",
                    UserId = new Guid("19dbd59c-cb4c-4f03-8703-08d96c7c875f")
                },
                new Comment
                {
                    Id = new Guid("005bc605-f6b6-42db-a24d-ca2884d7a68e"),
                    Header = "Header2",
                    Text = "some text some text some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text" +
                    " some text  some text  some text  some text  some text  some text  some text  some text  some text  some text",
                    UserId = new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a")
                },
                new Comment
                {
                    Id = new Guid("d975dfe7-c50a-4c62-aaa9-b2897c0fd330"),
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
