using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Integrations.Adfs
{
    public class MockDirectoryService : IDirectoryService
    {


        public ADUser AuthenticateADUser(string login, string password)
        {
            return this.Users.FirstOrDefault(c =>
            c.AccountName.Equals(login, StringComparison.InvariantCultureIgnoreCase) &&
            "micr0s0ft_".Equals(password));
        }

        public bool CheckADUserPassword(string login, string password)
        {
            return AuthenticateADUser(login, password) != null ? true : false;
        }


        public IEnumerable<ADUser> GetADUserBy(string keyword)
        {
            Func<ADUser, bool> predicate = (user) =>
            {

                if (user.AccountName.Equals(keyword, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                if (user.GivenName.Equals(keyword, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                if (user.LastName.Equals(keyword, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                if (user.Email.Equals(keyword, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                if (user.EmployeeID.Equals(keyword, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                return false;
            };

            return Users.Where(predicate);
        }

        private IEnumerable<ADUser> Users
        {
            get
            {
                yield return new ADUser()
                {
                    Title = "Mr",
                    AccountName = "Maya",
                    GivenName = "Maya",
                    LastName = "Didas",
                    Email = "MayaDidas@vericore.com",
                    EmployeeID = "006"
                };
                yield return new ADUser()
                {
                    Title = "Mr",
                    AccountName = "Ira",
                    GivenName = "Ira",
                    LastName = "Membrit",
                    Email = "IraMembrit@vericore.com",
                    EmployeeID = "006"
                };
                yield return new ADUser()
                {
                    Title = "Mr",
                    AccountName = "Paul",
                    GivenName = "Paul",
                    LastName = "Molive",
                    Email = "PaulMolive@vericore.com",
                    EmployeeID = "006"
                };

                yield return new ADUser()
                {
                    Title = "Mrs.",
                    AccountName = "Anna",
                    GivenName = "Anna",
                    LastName = "Sthesia",
                    Email = "AnnaSthesia@vericore.com",
                    EmployeeID = "005"
                };
                yield return new ADUser()
                {
                    Title = "Mr.",
                    AccountName = "Petey",
                    GivenName = "Petey",
                    LastName = "Cruiser",
                    Email = "PeteyCruiser@vericore.com",
                    EmployeeID = "004"
                };

                yield return new ADUser()
                {
                    Title = "Mrs.",
                    AccountName = "Mario",
                    GivenName = "Mario",
                    LastName = "Speedwagon",
                    Email = "MarioSpeedwagon@vericore.com",
                    EmployeeID = "004"
                };
                yield return new ADUser()
                {
                    Title = "Mrs.",
                    AccountName = "Bob",
                    GivenName = "Bob",
                    LastName = "Frapples",
                    Email = "BobFrapples@vericore.com",
                    EmployeeID = "003"
                };
                yield return new ADUser()
                {
                    Title = "Mr.",
                    AccountName = "Turner",
                    GivenName = "Paige",
                    LastName = "Turner",
                    Email = "PaigeTurner@vericore.com",
                    EmployeeID = "002"
                };
                yield return new ADUser()
                {
                    Title = "Mr.",
                    AccountName = "generalmanager",
                    GivenName = "John",
                    LastName = "Doe",
                    Email = "generalmanager@vericore.com",
                    EmployeeID = "001"
                };
            }
        }
    }
}
