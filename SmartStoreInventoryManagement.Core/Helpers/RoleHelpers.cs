using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Helpers
{
    public static class RoleHelpers
    {
        public static Guid SYS_ADMIN_ID() => Guid.Parse("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7");
        public const string SYS_ADMIN = nameof(SYS_ADMIN);

        public static Guid SUPER_ADMIN_ID() => Guid.Parse("0718ddef-4067-4f29-aaa1-98c1548c1807");
        public const string SUPER_ADMIN = nameof(SUPER_ADMIN);

        public static Guid SUPER_USER_ID() => Guid.Parse("8b93d395-a71a-4620-9352-5b9e6b3b6045");
        public const string SUPERUSER = nameof(SUPERUSER);

        public static Guid STAFF_USER_ID() => Guid.Parse("02bde570-4aa8-4c60-a462-07154aa69520");
        public const string STAFF_USER = nameof(STAFF_USER);



        public static List<string> GetAll()
        {
            return new List<string> { SYS_ADMIN, SUPER_ADMIN, SUPERUSER, STAFF_USER };
        }
    }
}

