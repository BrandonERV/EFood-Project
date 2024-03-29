﻿using EFood.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Configuration
{
    public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {

            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.ProductId).HasColumnName("productId").IsRequired();
            builder.Property(e => e.PriceTypeId).HasColumnName("priceTypeId").IsRequired();
            builder.Property(e => e.Amount).HasColumnName("amount").IsRequired();

            builder.HasOne(d => d.PriceType).WithMany()
                .HasForeignKey(d => d.PriceTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Product).WithMany()
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
