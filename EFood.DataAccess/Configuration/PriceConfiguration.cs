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
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {

            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Amount).HasColumnName("amount").IsRequired();
            builder.Property(e => e.PriceTypeId).HasColumnName("priceTypeId").IsRequired();

            builder.HasOne(d => d.PriceType).WithMany()
                .HasForeignKey(d => d.PriceTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }


}
