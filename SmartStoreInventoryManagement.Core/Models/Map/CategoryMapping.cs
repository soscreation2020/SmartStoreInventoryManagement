using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class CategoryMapping : BaseEntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(s => s.CategorNumber).HasMaxLength(300);
            builder.Property(s => s.Name).HasMaxLength(300);
            builder.Property(s => s.Description).HasMaxLength(300);

            base.Configure(builder);
        }
    }
}
