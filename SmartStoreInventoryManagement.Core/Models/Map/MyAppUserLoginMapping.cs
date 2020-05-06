using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class MyAppUserLoginMapping : IEntityTypeConfiguration<MyAppUserLogin>
    {
        public void Configure(EntityTypeBuilder<MyAppUserLogin> builder)
        {
            builder.ToTable(nameof(MyAppUserLogin));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasKey(u => new { u.LoginProvider, u.ProviderKey });
        }
    }
}
