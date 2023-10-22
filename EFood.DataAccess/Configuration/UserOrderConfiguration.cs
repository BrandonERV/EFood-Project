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
    public class UserOrderConfiguration : IEntityTypeConfiguration<UserOrder>
    {
        public void Configure(EntityTypeBuilder<UserOrder> builder)
        {


            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.OrdersId).HasColumnName("ordersId").IsRequired();
            builder.Property(e => e.UserId).HasColumnName("userId").IsRequired();

            builder.HasOne(d => d.Orders).WithMany()
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
