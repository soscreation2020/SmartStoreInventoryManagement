using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class VendorMapping : BaseEntityTypeConfiguration<Vendor>
    {
        public override void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(350);
            builder.Property(s => s.Address).HasMaxLength(500);
            builder.Property(s => s.EmailAddress).HasMaxLength(300);
            builder.Property(s => s.OfficeNumber).HasMaxLength(13);

            base.Configure(builder);
        }

    }
}
