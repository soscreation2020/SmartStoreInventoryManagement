using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class MyAppUserTokenMapping : IEntityTypeConfiguration<MyAppUserToken>
    {
        public void Configure(EntityTypeBuilder<MyAppUserToken> builder)
        {
            builder.ToTable(nameof(MyAppUserToken));
            builder.HasKey(p => p.UserId);
        }
    }
}
