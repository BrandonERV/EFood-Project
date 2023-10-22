using EFood.models;
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
            builder.Property(e => e.PriceId).HasColumnName("priceId").IsRequired();
            builder.Property(e => e.ProductId).HasColumnName("productId").IsRequired();

            builder.HasOne(d => d.Price).WithMany()
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
