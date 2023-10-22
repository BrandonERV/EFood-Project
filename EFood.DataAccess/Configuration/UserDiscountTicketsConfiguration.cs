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
    public class UserDiscountTicketsConfiguration : IEntityTypeConfiguration<UserDiscountTicket>
    {
        public void Configure(EntityTypeBuilder<UserDiscountTicket> builder)
        {

            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.TicketId).HasColumnName("ticketId").IsRequired();
            builder.Property(e => e.UserId).HasColumnName("userId").IsRequired();

            builder.HasOne(d => d.Ticket).WithMany()
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
