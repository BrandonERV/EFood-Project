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
    public class OrdersProductConfiguration : IEntityTypeConfiguration<OrdersProduct>
    {
        public void Configure(EntityTypeBuilder<OrdersProduct> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.OrdersId).HasColumnName("ordersId").IsRequired();
            builder.Property(e => e.ProductId).HasColumnName("productId").IsRequired();

            builder.HasOne(d => d.Orders).WithMany()
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
