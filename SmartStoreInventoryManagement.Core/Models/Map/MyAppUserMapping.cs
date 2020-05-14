using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStoreInventoryManagement.Core.Enums;
using SmartStoreInventoryManagement.Core.Models.Statics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class MyAppUserMapping : IEntityTypeConfiguration<MyAppUser>
    {
        public MyAppUserMapping()
        {

        }
        public PasswordHasher<MyAppUser> Hasher { get; set; } = new PasswordHasher<MyAppUser>();

        public void Configure(EntityTypeBuilder<MyAppUser> builder)
        {
            builder.ToTable(nameof(MyAppUser));
            builder.Property(b => b.FirstName).HasMaxLength(150);
            builder.Property(b => b.LastName).HasMaxLength(150);
            builder.Property(b => b.MiddleName).HasMaxLength(150);
            SetupSuperAdmin(builder);
            SetupPowerUser(builder);
            SetupStaff(builder);
        }

        private void SetupSuperAdmin(EntityTypeBuilder<MyAppUser> builder)
        {
            var sysUser = new MyAppUser
            {
                Activated = true,
                CreatedOnUtc = new DateTime(2019, 09, 16),
                FirstName = "Olaleye",
                LastName = "Walure",
                Id = Defaults.SysUserId,
                LastLoginDate = new DateTime(2019, 09, 16),
                Email = Defaults.SysUserEmail,
                EmailConfirmed = true,
                NormalizedEmail = Defaults.SysUserEmail.ToUpper(),
                PhoneNumber = Defaults.SysUserMobile,
                UserName = Defaults.SysUserEmail,
                NormalizedUserName = Defaults.SysUserEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "micr0s0ft_"),
                SecurityStamp = "99ae0c45-d682-4542-9ba7-1281e471916b",
                UserType = UserTypes.ADMIN,
            };

            var superUser = new MyAppUser
            {
                Activated = true,
                CreatedOnUtc = new DateTime(2019, 09, 16),
                Id = Defaults.SuperAdminId,
                FirstName = "Olaleye",
                LastName = "Walure",
                LastLoginDate = new DateTime(2019, 09, 16),
                Email = Defaults.SuperAdminEmail,
                EmailConfirmed = true,
                NormalizedEmail = Defaults.SuperAdminEmail.ToUpper(),
                PhoneNumber = Defaults.SuperAdminMobile,
                UserName = Defaults.SuperAdminEmail,
                NormalizedUserName = Defaults.SuperAdminEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "micr0s0ft_"),
                SecurityStamp = "016020e3-5c50-40b4-9e66-bba56c9f5bf2",
                UserType = UserTypes.STAFF
            };

            builder.HasData(sysUser, superUser);
        }
        private void SetupPowerUser(EntityTypeBuilder<MyAppUser> builder)
        {
            var powerUser = new MyAppUser
            {
                Activated = true,
                CreatedOnUtc = new DateTime(2019, 09, 16),
                FirstName = "Prolifik",
                LastName = "Lexzy",
                Id = Defaults.PowerUserId,
                LastLoginDate = new DateTime(2019, 09, 16),
                Email = Defaults.PowerUserEmail,
                EmailConfirmed = true,
                NormalizedEmail = Defaults.PowerUserEmail.ToUpper(),
                PhoneNumber = Defaults.PowerUserMobile,
                UserName = Defaults.PowerUserEmail,
                NormalizedUserName = Defaults.PowerUserEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "micr0s0ft_"),
                SecurityStamp = "7d728c76-1c51-491a-99db-bde6a5b0655b",
                UserType = UserTypes.POWER_USERS,
            };

            builder.HasData(powerUser);
        }
        private void SetupStaff(EntityTypeBuilder<MyAppUser> builder)
        {
            var StaffUser = new MyAppUser
            {
                Activated = true,
                CreatedOnUtc = new DateTime(2019, 09, 16),
                FirstName = "Bolaji",
                LastName = "Siraj",
                Id = Defaults.StaffId,
                LastLoginDate = new DateTime(2019, 09, 16),
                Email = Defaults.StaffEmail,
                EmailConfirmed = true,
                NormalizedEmail = Defaults.StaffEmail.ToUpper(),
                PhoneNumber = Defaults.StaffMobile,
                UserName = Defaults.StaffEmail,
                NormalizedUserName = Defaults.StaffEmail.ToUpper(),
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "micr0s0ft_"),
                SecurityStamp = "953d3fd1-99e3-4fe7-a20d-3598baa96099",
                UserType = UserTypes.STAFF,
            };

            builder.HasData(StaffUser);
        }
    }
}
