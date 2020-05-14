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
   public interface IProductService
    {
        Task<List<ValidationResult>> Setup(ProductViewModel viewModel, Guid userId);
        Task<List<ValidationResult>> Edit(ProductEditViewModel viewModel, Guid createdBy);
        Task<List<ValidationResult>> Delete(Guid id, Guid createdBy);
        Task<ApiResponse<List<ProductListViewModel>>> GetAll(SearchProductViewModel viewModel);
        Task<ApiResponse<ProductListViewModel>> GetById(Guid id);
        Product Find(Guid id);//I only declare it here cos we are using interface
        void Update(Product entity);
        void AddProduct(ProductViewModel department, Guid userId);
        IEnumerable<ProductDto> SpGetAllProduct(string Keyword, int? pageIndex, int? pageSize);
    }
}
