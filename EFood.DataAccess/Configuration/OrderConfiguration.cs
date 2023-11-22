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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Amount).HasColumnName("amount").IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date").IsRequired();
            builder.Property(e => e.PaymentProcessorId).HasColumnName("paymentProcessorId").IsRequired();
            builder.Property(e => e.StatusId).HasColumnName("statusId").IsRequired();
            builder.Property(e => e.ClientName).IsRequired(false);
            builder.Property(e => e.Adress).IsRequired(false);
            builder.Property(e => e.PhoneNumber).IsRequired(false);

            builder.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(d => d.PaymentProcessor).WithMany()
                .HasForeignKey(d => d.PaymentProcessorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Status).WithMany()
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
