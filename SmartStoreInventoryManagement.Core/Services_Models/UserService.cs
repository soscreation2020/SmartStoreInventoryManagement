using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SmartStoreInventoryManagement.Core.Models;
using SmartStoreInventoryManagement.Core.Services;
using SmartStoreInventoryManagement.Core.Services_Models.Interface;
using SmartStoreInventoryManagement.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.Services_Models
{
    public class UserService :  IUserService
    {
        // private readonly IPasswordHasher<MyAppUser> _passwordHasher;
        private readonly UserManager<MyAppUser> _userManager;
        private readonly RoleManager<MyAppRole> _roleManager;
        private readonly ILogger<UserService> _logger;
        public UserService(//IPasswordHasher<MyAppUser> passwordHasher,
            UserManager<MyAppUser> userManager,  RoleManager<MyAppRole> roleManager, ILogger<UserService> logger) 
        {
           // _passwordHasher = passwordHasher;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;

        }

        //public async Task<IEnumerable<UserEditViewModel>> GetUserByRole(string role)
        //{
        //    var users = await _userManager.GetUsersInRoleAsync(role);

        //    if (!users.Any())
        //        return Enumerable.Empty<UserEditViewModel>();

        //    return users.Select(u => new UserEditViewModel()
        //    {
        //        Id = u.Id.ToString(),
        //        LastName = u.LastName,
        //        FirstName = u.FirstName,
        //        MiddleName = u.MiddleName,
        //        Email = u.Email,
        //        PhoneNumber = u.PhoneNumber,
        //    });
        //}

        public async Task<IEnumerable<Claim>> GetClaims(MyAppUser appUser)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, appUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, appUser.Id.ToString()),
            };

            var userClaims = await _userManager.GetClaimsAsync(appUser);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(appUser);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return claims;
        }
    }
}
