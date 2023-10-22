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
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {

        public void Configure(EntityTypeBuilder<Card> builder) 
        {
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name").IsRequired();

        }
    }
}
