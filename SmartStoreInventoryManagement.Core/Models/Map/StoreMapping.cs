using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
   public class StoreMapping : BaseEntityTypeConfiguration<Store>
    {
        public override void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(500);
            builder.Property(s => s.StockQuantity).HasMaxLength(500);
            builder.Property(s => s.Description).HasMaxLength(500);
            base.Configure(builder);
        }
    }
}
