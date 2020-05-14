using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
   public class RequestOrderDetailMapping : BaseEntityTypeConfiguration<RequestOrderDetail>
    {
        public override void Configure(EntityTypeBuilder<RequestOrderDetail> builder)
        {
            
            base.Configure(builder);
        }
    }
}
