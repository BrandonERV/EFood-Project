using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFood.models;

namespace EFood.DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {


            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description").IsRequired();
            builder.Property(e => e.FoodLineId).HasColumnName("foodLineId").IsRequired();
            builder.Property(e => e.Image).IsRequired();
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name").IsRequired();

            builder.HasOne(d => d.FoodLine).WithMany()
                .HasForeignKey(d => d.FoodLineId)
                .OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
