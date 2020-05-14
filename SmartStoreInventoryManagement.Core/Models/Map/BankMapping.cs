using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class BankMapping : BaseEntityTypeConfiguration<Bank>
    {
        public override void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(350);
            builder.Property(s => s.AbbrCode).HasMaxLength(500);
            base.Configure(builder);
        }

    }
}
