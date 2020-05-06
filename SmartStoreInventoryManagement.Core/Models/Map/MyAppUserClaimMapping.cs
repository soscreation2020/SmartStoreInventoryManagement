using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class MyAppUserClaimMapping : IEntityTypeConfiguration<MyAppUserClaim>
    {
        public void Configure(EntityTypeBuilder<MyAppUserClaim> builder)
        {
            builder.ToTable(nameof(MyAppUserClaim));
            builder.HasKey(c => c.Id);
        }
    }
}
