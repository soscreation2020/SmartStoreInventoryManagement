using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class PurchaseOrderDetailMapping : BaseEntityTypeConfiguration<PurchaseOrderDetail>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            
            base.Configure(builder);
        }
    }
}
