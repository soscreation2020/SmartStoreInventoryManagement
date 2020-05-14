using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
   public class BankAccountMapping : BaseEntityTypeConfiguration<BankAccount>
    {
        public override void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(s => s.AccountNo).HasMaxLength(13);
            builder.Property(s => s.Title).HasMaxLength(500);
            base.Configure(builder);
        }
    }
}
