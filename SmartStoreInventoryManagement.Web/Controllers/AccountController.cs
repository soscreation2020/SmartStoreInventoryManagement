using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartStoreInventoryManagement.Core.AspNetCore;
using SmartStoreInventoryManagement.Core.Integrations.Adfs;
using SmartStoreInventoryManagement.Core.Models;
using SmartStoreInventoryManagement.Core.Services_Models.Interface;
using SmartStoreInventoryManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Web.Controllers
{
    //[Route("[controller]/[action]")]
    public class AccountController : BaseMvcController
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<MyAppUser> _userManager;
        private readonly SignInManager<MyAppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IDirectoryService _directoryService;


        public AccountController(IConfiguration configuration, UserManager<MyAppUser> userManager, SignInManager<MyAppUser> signInManager
       , IUserService userService, IDirectoryService directoryService , ITokenService tokenService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _tokenService = tokenService;
            _directoryService = directoryService;
        }




        [HttpGet]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Login", "Account");
        }
       

        [AllowAnonymous]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("InvalidCredentials", "Invalid credentials.");
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("InvalidCredentials", "Invalid credentials.");
                return View(model);
            }
            //var adResult = "Ok";
            var isValid = await _userManager.CheckPasswordAsync(user, model.Password);
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            //Ad integration
            var adResult = _directoryService.CheckADUserPassword(user.UserName, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("InvalidCredentials", "Invalid credentials.");
                return View(model);
            }

            var properties = new AuthenticationProperties
            {
                IsPersistent = true,
            };

            var claims = await _userService.GetClaims(user);
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaims(claims);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


            if (IsUrlValid(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }


            return RedirectToAction("Index", "Home");

        }

        private static bool IsUrlValid(string returnUrl)
        {
            return !string.IsNullOrWhiteSpace(returnUrl)
                   && Uri.IsWellFormedUriString(returnUrl, UriKind.Relative);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}
