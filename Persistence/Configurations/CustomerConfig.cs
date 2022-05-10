using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(cust => cust.Id);

            builder.Property(cust => cust.Name)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(cust => cust.LastName)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(cust => cust.BirthDate)
                .IsRequired();

            builder.Property(cust => cust.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(cust => cust.Address)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(cust => cust.Email)
                .HasMaxLength(50);
            
            builder.Property(cust => cust.Age);

            builder.Property(cust => cust.CreatedBy)
                .HasMaxLength(30);
            
            builder.Property(cust => cust.LastModifiedBy)
                .HasMaxLength(30);
        }
    }
}
