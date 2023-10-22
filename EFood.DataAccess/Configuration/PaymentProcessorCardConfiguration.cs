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
    public class PaymentProcessorCardConfiguration : IEntityTypeConfiguration<PaymentProcessorCard>
    {
        public void Configure(EntityTypeBuilder<PaymentProcessorCard> builder)
        {


            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.CardId).HasColumnName("cardId").IsRequired();
            builder.Property(e => e.PaymentProcessorId).HasColumnName("paymentProcessorId").IsRequired();

            builder.HasOne(d => d.Card).WithMany()
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.PaymentProcessor).WithMany()
                .HasForeignKey(d => d.PaymentProcessorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
