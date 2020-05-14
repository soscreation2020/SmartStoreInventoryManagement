using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
   public class BranchMapping : BaseEntityTypeConfiguration<Branch>
    {
        public override void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(300);
            builder.Property(s => s.Description).HasMaxLength(500);
            base.Configure(builder);
        }
    }
}
