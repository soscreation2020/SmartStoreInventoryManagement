using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
   public class PurchaseOderMapping : BaseEntityTypeConfiguration<PurchaseOder>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOder> builder)
        {
            
            base.Configure(builder);
        }
    }
}
