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
            builder.Property(e => e.Status)
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
            builder.Property(e => e.Processor)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("processor").IsRequired();
            builder.Property(e => e.Verification)
                .IsUnicode(false)
                .HasColumnName("verification").IsRequired();
            builder.Property(e => e.Method)
                .IsUnicode(false)
                .HasColumnName("method").IsRequired();
        }
    }
}
