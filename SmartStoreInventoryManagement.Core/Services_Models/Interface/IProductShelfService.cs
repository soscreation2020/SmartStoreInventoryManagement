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
   public interface IProductShelfService
    {
        Task<List<ValidationResult>> Setup(ProductShelfViewModel viewModel, Guid userId);
        Task<List<ValidationResult>> Edit(ProductShelfEditViewModel viewModel, Guid createdBy);
        Task<List<ValidationResult>> Delete(Guid id, Guid createdBy);
        Task<ApiResponse<List<ProductShelfListViewModel>>> GetAll(SearchProductShelfViewModel viewModel);
        Task<ApiResponse<ProductShelfListViewModel>> GetById(Guid id);
        ProductShelf Find(Guid id);//I only declare it here cos we are using interface
        void Update(ProductShelf entity);
        void AddProductShelf(ProductShelfViewModel department, Guid userId);
        IEnumerable<ProductShelfDto> SpGetAllProductShelf(string Keyword, int? pageIndex, int? pageSize);
    }
}
