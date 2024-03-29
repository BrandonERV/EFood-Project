﻿using System;
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
            builder.Property(e => e.ClientName).IsRequired();
            builder.Property(e => e.Adress).IsRequired();
            builder.Property(e => e.PhoneNumber).IsRequired();
            builder.Property(e => e.PaymentType).IsRequired();
            builder.Property(e => e.CardType).IsRequired();
            builder.Property(e => e.IsCard).IsRequired();
            builder.Property(e => e.IsPayCheck).IsRequired();
            builder.Property(e => e.IsPayCash).IsRequired();
            builder.Property(e => e.CardNumber).IsRequired(false);
            builder.Property(e => e.PayCheckNumber).IsRequired(false);
            builder.Property(e => e.PayCheckBankAccountNumber).IsRequired(false);

            builder.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
