using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Integrations.Adfs
{
    public interface IDirectoryService
    {
        IEnumerable<ADUser> GetADUserBy(string keyword);
        bool CheckADUserPassword(string login, string password);
        ADUser AuthenticateADUser(string login, string password);
    }
}
