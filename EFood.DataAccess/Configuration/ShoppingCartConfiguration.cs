using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFood.models;
using EFood.Models;

namespace EFood.DataAccess.Configuration

{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {

        public void Configure(EntityTypeBuilder<ShoppingCart> builder) 
        {
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.Price).IsRequired();


            builder.HasOne(x => x.User).WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Product).WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
