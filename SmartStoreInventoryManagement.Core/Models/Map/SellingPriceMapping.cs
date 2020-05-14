using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
   public class SellingPriceMapping : BaseEntityTypeConfiguration<SellingPrice>
    {
        public override void Configure(EntityTypeBuilder<SellingPrice> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(300);
            builder.Property(s => s.PriceNumber).HasMaxLength(500);
            base.Configure(builder);
        }
    }
}
