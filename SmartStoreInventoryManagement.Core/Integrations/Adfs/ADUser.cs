using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Integrations.Adfs
{
    public class ADUser
    {
        public string Id { get { return AccountName; } }
        public string Title { get; set; }
        public string EmployeeID { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public string AccountName { get; set; }
        public string UserPrincipal { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}
