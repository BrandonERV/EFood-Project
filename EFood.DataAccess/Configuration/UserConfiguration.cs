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

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(e => e.Id).HasColumnName("id").IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("email").IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name").IsRequired();

            builder.Property(e => e.Password)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("password").IsRequired();

            builder.Property(e => e.SecurityAnswer)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("securityAnswer").IsRequired();

            builder.Property(e => e.SecurityQuestion)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("securityQuestion").IsRequired();

            builder.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("status").IsRequired();

        }
    }
}
