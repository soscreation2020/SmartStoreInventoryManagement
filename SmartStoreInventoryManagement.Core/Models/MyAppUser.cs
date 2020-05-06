using Microsoft.AspNetCore.Identity;
using SmartStoreInventoryManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Models
{
    [Table(nameof(MyAppUser))]
    public class MyAppUser : IdentityUser<Guid>, AEntity
    {
        public MyAppUser()
        {
            Id = Guid.NewGuid();
            CreatedOnUtc = DateTime.UtcNow;
        }

        public string RefreshToken { get; set; }
        public string ProviderKey { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Gender { get; set; }
        public string PictureUrl { get; set; }

        public bool SystemUser { get; set; }

        public bool CanUseApplication { get; set; }

        public DateTime? LastLoginDateUtc { get; set; }

        public DateTime JoinDate { get; set; }

        public UserTypes UserType { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {

                return $"{LastName} {FirstName}";
            }
        }

        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool Activated { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class MyAppUserClaim : IdentityUserClaim<Guid>
    {
    }

    public class MyAppUserLogin : IdentityUserLogin<Guid>
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }

    public class MyAppRole : IdentityRole<Guid>
    {
        public MyAppRole()
        {
            Id = Guid.NewGuid();
            ConcurrencyStamp = Guid.NewGuid().ToString("N");
        }
    }

    public class MyAppUserRole : IdentityUserRole<Guid>
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }

    public class MyAppRoleClaim : IdentityRoleClaim<Guid>
    {
        //public int id { get; set; }

    }

    public class MyAppUserToken : IdentityUserToken<Guid>
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
