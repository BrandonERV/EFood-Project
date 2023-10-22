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
    public class LogbookConfiguration : IEntityTypeConfiguration<Logbook>
    {
        public void Configure(EntityTypeBuilder<Logbook> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Date).HasColumnType("date").HasColumnName("date").IsRequired();
            builder.Property(e => e.Description).HasMaxLength(250).IsUnicode(false).HasColumnName("description").IsRequired();
            builder.Property(e => e.RegisterCode).HasColumnName("registerCode").IsRequired();
            builder.Property(e => e.UserId).HasColumnName("userId").IsRequired();

            builder.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
