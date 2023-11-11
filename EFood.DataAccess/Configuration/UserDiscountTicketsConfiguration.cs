using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFood.models;

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