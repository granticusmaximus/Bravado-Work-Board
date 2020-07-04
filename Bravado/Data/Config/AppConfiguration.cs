using System;
using Bravado.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravado.Data.Config
{
    public class AppConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
        }
    }
}
