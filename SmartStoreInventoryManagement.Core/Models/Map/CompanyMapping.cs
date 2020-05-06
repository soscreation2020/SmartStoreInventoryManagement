using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class CompanyMapping : BaseEntityTypeConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(150);
            builder.Property(s => s.Description).HasMaxLength(300);
            builder.Property(s => s.Address).HasMaxLength(500);
            builder.Property(s => s.EmailAddress).HasMaxLength(300);
            builder.Property(s => s.OfficeNo).HasMaxLength(13);

            base.Configure(builder);
        }
    }
}
