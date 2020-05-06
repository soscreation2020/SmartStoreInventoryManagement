using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStoreInventoryManagement.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class MyAppRoleMapping : IEntityTypeConfiguration<MyAppRole>
    {
        public void Configure(EntityTypeBuilder<MyAppRole> builder)
        {
            builder.ToTable(nameof(MyAppRole));
            SetupData(builder);
        }



        private void SetupData(EntityTypeBuilder<MyAppRole> builder)
        {
            var roles = new MyAppRole[]
            {
                new MyAppRole
                {
                    Id = RoleHelpers.SYS_ADMIN_ID(),
                    Name = RoleHelpers.SYS_ADMIN,
                    NormalizedName = RoleHelpers.SYS_ADMIN.ToString()
                },
                new MyAppRole
                {
                    Id = RoleHelpers.SUPER_ADMIN_ID(),
                    Name = RoleHelpers.SUPER_ADMIN,
                    NormalizedName = RoleHelpers.SUPER_ADMIN.ToString()
                },
                 new MyAppRole
                {
                    Id = RoleHelpers.SUPER_USER_ID(),
                    Name = RoleHelpers.SUPERUSER,
                    NormalizedName = RoleHelpers.SUPERUSER.ToString()
                },
                  new MyAppRole
                {
                    Id = RoleHelpers.STAFF_USER_ID(),
                    Name = RoleHelpers.STAFF_USER,
                    NormalizedName = RoleHelpers.STAFF_USER.ToString()
                },

            };

            builder.HasData(roles);
        }
    }
}
