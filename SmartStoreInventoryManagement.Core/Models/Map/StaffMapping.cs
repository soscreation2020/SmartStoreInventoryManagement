using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStoreInventoryManagement.Core.Models.Statics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Map
{
    public class StaffMapping : BaseEntityTypeConfiguration<Staff>
    {
        public override void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(b => b.Title).HasMaxLength(50);
            builder.Property(b => b.StaffNo).HasMaxLength(100);
            base.Configure(builder);
            SetupStaff(builder);
        }

        private void SetupStaff(EntityTypeBuilder<Staff> builder)
        {
            var createdBy = new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc);
            var fullStaff = new Staff()
            {
                Id = Defaults.StaffID1,
                Title = "Mrs.",
                User_Id = Defaults.PowerUserId,
                StaffNo = "0001",
                CreatedBy = Defaults.SysUserId,
                CreatedOn = createdBy,
                ModifiedBy = Defaults.SysUserId,
                ModifiedOn = createdBy
            };

            builder.HasData(fullStaff);

            var contract = new Staff()
            {
                Id = Defaults.StaffID2,
                Title = "Mr",
                User_Id = Defaults.StaffId,
                StaffNo = "0002",
                CreatedBy = Defaults.SysUserId,
                CreatedOn = createdBy,
                ModifiedBy = Defaults.SysUserId,
                ModifiedOn = createdBy
            };

            builder.HasData(contract);

            var outSource = new Staff()
            {
                Id = Defaults.StaffID3,
                Title = "Mr",
                User_Id = Defaults.StaffId,
                StaffNo = "0003",
                CreatedBy = Defaults.SysUserId,
                CreatedOn = createdBy,
                ModifiedBy = Defaults.SysUserId,
                ModifiedOn = createdBy
            };

            builder.HasData(outSource);
        }
    }
}
