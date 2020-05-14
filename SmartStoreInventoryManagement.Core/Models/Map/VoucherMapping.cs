using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
   public class VoucherMapping : BaseEntityTypeConfiguration<Voucher>
    {
        public override void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.Property(s => s.VoucherNumber).HasMaxLength(500);
            
            base.Configure(builder);
        }
    }
}
