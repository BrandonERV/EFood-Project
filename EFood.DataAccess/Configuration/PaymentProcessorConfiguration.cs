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
    public class PaymentProcessorConfiguration : IEntityTypeConfiguration<PaymentProcessor>
    {
        public void Configure(EntityTypeBuilder<PaymentProcessor> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Active)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("active").IsRequired();
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name").IsRequired();
            builder.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type").IsRequired();
        }
    }
}
