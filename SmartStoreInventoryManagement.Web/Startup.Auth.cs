using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Web
{
    public partial class Startup
    {
        public static void ConfigureAuth(IServiceCollection services)
        {
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
            //    options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
            //    options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            //});

            services.AddAuthentication()
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(int.Parse(Configuration["Tokens:TokenExpiry"]));
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
          ctx.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        return Task.FromResult(0);
                    }
                };

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;

                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidAudience = Configuration["Tokens:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:SecretKey"]))
                };
            });

        }
    }
}
