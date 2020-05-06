using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models.Statics
{
    public partial class Defaults
    {
        public const string SysUserEmail = "system@smartstore.com";
        public static readonly Guid SysUserId = Guid.Parse("1989883f-4f99-43bf-a754-239bbbfec00e");
        public const string SysUserMobile = "08067623699";
        public const string SuperAdminEmail = "superadmin@smartstore.com";
        public static readonly Guid SuperAdminId = Guid.Parse("3fb897c8-c25d-4328-9813-cb1544369fba");
        public const string SuperAdminMobile = "08067623699";
        public static Guid PowerUserId = Guid.Parse("973AF7A9-7F18-4E8B-ACD3-BC906580561A");
        public const string PowerUserEmail = "storemanager@vericore.com";
        public const string PowerUserMobile = "08062066851";
        public static readonly Guid StaffId = Guid.Parse("129712e3-9214-4dd3-9c03-cfc4eb9ba979");
        public const string StaffMobile = "08062066851";
        public const string StaffEmail = "staff@smartstore.com";

    }
}
