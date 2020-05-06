using SmartStoreInventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.Services_Models.Interface
{
    public interface IUserService
    {
        //Task<IEnumerable<UserEditViewModel>> GetUserByRole(string role);
        Task<IEnumerable<Claim>> GetClaims(MyAppUser appUser);
        //Task<List<ValidationResult>> SetupUser(UserSetUpViewModel viewModel, Guid createdBy, string userName);
        //Task<ApiResponse<List<UserListViewModel>>> GetAllUsers(SearchUserViewModel viewModel);
        //Task<ApiResponse<UserListViewModel>> GetById(Guid id);
        //Task<List<ValidationResult>> DeleteUser(UserEditViewModel viewModel, Guid createdBy, string userName);
        //Task<List<ValidationResult>> EditUser(UserEditViewModel viewModel, Guid createdBy, string userName);
        //Task<List<ValidationResult>> AddRoleAsync(RoleViewModel model);
        //Task<List<ValidationResult>> EditRoleAsync(EditRoleViewModel model);
    }
}
