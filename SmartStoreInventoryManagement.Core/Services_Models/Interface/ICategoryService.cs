using SmartStoreInventoryManagement.Core.Dto;
using SmartStoreInventoryManagement.Core.Models;
using SmartStoreInventoryManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.Services_Models.Interface
{
   public interface ICategoryService
    {
        Task<List<ValidationResult>> SetupCategory(CategoryViewModel viewModel, Guid userId);
        Task<List<ValidationResult>> EditCategory(CategoryEditViewModel viewModel, Guid createdBy);
        Task<List<ValidationResult>> DeleteCategory(Guid id, Guid createdBy);
        Task<ApiResponse<List<CategoryListViewModel>>> GetAllCategory(SearchCategoryViewModel viewModel);
        Task<ApiResponse<CategoryListViewModel>> GetCategoryById(Guid id);
        Category Find(Guid id);//I only declare it here cos we are using interface
        void Update(Category entity);
        void AddDepartment(CategoryViewModel department, Guid userId);
        IEnumerable<CategoryDto> SpGetAllCategory(string Keyword, int? pageIndex, int? pageSize);
    }
}
