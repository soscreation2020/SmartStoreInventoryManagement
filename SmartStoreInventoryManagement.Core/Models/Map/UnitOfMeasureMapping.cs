using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    class UnitOfMeasureMapping : BaseEntityTypeConfiguration<UnitOfMeasure>
    {
        public override void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(300);
            base.Configure(builder);
        }
    }
}
