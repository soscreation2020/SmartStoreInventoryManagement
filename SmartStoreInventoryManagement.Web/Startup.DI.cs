using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartStoreInventoryManagement.Core.EF.Context;
using SmartStoreInventoryManagement.Core.Integrations.Adfs;
using SmartStoreInventoryManagement.Core.Models;
using SmartStoreInventoryManagement.Core.Reposory;
using SmartStoreInventoryManagement.Core.Services;
using SmartStoreInventoryManagement.Core.Services_Models;
using SmartStoreInventoryManagement.Core.Services_Models.Interface;
using SmartStoreInventoryManagement.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Web
{
    public partial class Startup
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(provider => Configuration);
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IPasswordHasher<MyAppUser>, PasswordHasher<MyAppUser>>();
            services.AddScoped<IDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));

            services.AddTransient<IProductShelfService, ProductShelfService>();
            services.AddTransient<IUnitOfMeasureService, UnitOfMeasureService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IDirectoryService, MockDirectoryService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
