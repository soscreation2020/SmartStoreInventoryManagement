using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStoreInventoryManagement.Core.Helpers;
using SmartStoreInventoryManagement.Core.Models.Statics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class MyAppUserRoleMapping : IEntityTypeConfiguration<MyAppUserRole>
    {
        public void Configure(EntityTypeBuilder<MyAppUserRole> builder)
        {
            builder.ToTable("MyAppUserRole");
            builder.HasKey(p => new { p.UserId, p.RoleId });
            SetupData(builder);
        }

        private void SetupData(EntityTypeBuilder<MyAppUserRole> builder)
        {
            List<MyAppUserRole> dataList = new List<MyAppUserRole>()
            {
                new MyAppUserRole()
                {
                    UserId = Defaults.SysUserId,
                    RoleId = RoleHelpers.SYS_ADMIN_ID(),
                },

                new MyAppUserRole()
                {
                    UserId = Defaults.SuperAdminId,
                    RoleId = RoleHelpers.SUPER_ADMIN_ID(),
                },
                 new MyAppUserRole()
                {
                    UserId = Defaults.PowerUserId,
                    RoleId = RoleHelpers.SUPER_USER_ID(),
                },

                new MyAppUserRole()
                {
                    UserId = Defaults.StaffId,
                    RoleId = RoleHelpers.STAFF_USER_ID(),
                },

            };

            builder.HasData(dataList);
        }
    }
}
