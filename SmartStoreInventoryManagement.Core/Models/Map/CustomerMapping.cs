using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class CustomerMapping : BaseEntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(s => s.FirstName).HasMaxLength(150);
            builder.Property(s => s.LastName).HasMaxLength(300);
            builder.Property(s => s.Address).HasMaxLength(500);
            builder.Property(s => s.State).HasMaxLength(300);
            builder.Property(s => s.TelNo).HasMaxLength(13);
            base.Configure(builder);
        }
    }
}