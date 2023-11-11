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
    public class DiscountTicketConfiguration : IEntityTypeConfiguration<DiscountTicket>
    {
        public void Configure(EntityTypeBuilder<DiscountTicket> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Availabletickets).HasColumnName("availabletickets").IsRequired();
            builder.Property(e => e.Discount).HasColumnName("discount").IsRequired();
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name").IsRequired();
        }

    }
}
