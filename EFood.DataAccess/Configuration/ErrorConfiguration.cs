using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFood.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EFood.DataAccess.Configuration
{
    public class ErrorConfiguration : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {

            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date").IsRequired();
            builder.Property(e => e.Message) 
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("message").IsRequired();

        }
    }
}
