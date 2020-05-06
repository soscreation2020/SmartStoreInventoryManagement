using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class MyAppRoleClaimMapping : IEntityTypeConfiguration<MyAppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<MyAppRoleClaim> builder)
        {
            builder.ToTable(nameof(MyAppRoleClaim));

        }
    }
}
