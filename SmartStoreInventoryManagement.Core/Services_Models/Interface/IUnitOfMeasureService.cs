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
   public interface IUnitOfMeasureService
    {
        Task<List<ValidationResult>> SetupUnitOfMeasure(UnitOfMeasureViewModel viewModel, Guid userId);
        Task<List<ValidationResult>> EditUnitOfMeasure(UnitOfMeasureEditViewModel viewModel, Guid createdBy);
        Task<List<ValidationResult>> DeleteUnitOfMeasure(Guid id, Guid createdBy);
        Task<ApiResponse<List<UnitOfMeasureListViewModel>>> GetAllUnitOfMeasure(SearchUnitOfMeasureViewModel viewModel);
        Task<ApiResponse<UnitOfMeasureListViewModel>> GetUnitOfMeasureById(Guid id);
        UnitOfMeasure Find(Guid id);//I only declare it here cos we are using interface
        void Update(UnitOfMeasure entity);
        void AddUnitOfMeasure(UnitOfMeasureViewModel department, Guid userId);
        IEnumerable<UnitOfMeasureDto> SpGetAllUnitOfMeasure(string Keyword, int? pageIndex, int? pageSize);
    }
}
