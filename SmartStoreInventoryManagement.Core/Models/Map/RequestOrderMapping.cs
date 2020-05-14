using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
  public  class RequestOrderMapping : BaseEntityTypeConfiguration<RequestOrder>
    {
        public override void Configure(EntityTypeBuilder<RequestOrder> builder)
        {
            builder.Property(s => s.RequestNumber).HasMaxLength(50);
            builder.Property(s => s.Description).HasMaxLength(500);
            base.Configure(builder);
        }
    }
}
