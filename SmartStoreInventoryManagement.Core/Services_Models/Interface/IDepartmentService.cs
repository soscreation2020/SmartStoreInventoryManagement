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
    public interface IDepartmentService
    {
        Task<List<ValidationResult>> SetupDepartment(DepartmentViewModel viewModel, Guid userId);
        Task<List<ValidationResult>> EditDepartmet(DepartmentEditViewModel viewModel, Guid createdBy);
        Task<List<ValidationResult>> DeleteDepartment(Guid id, Guid createdBy);
        Department Find(Guid id);//I only declare it here cos we are using interface
        //void EditDepartments(Department department);
        void Update(Department entity);
        Task<ApiResponse<List<DepartmentListViewModel>>> GetAllDepartment(SearchDepartmentViewModel viewModel);
        Task<ApiResponse<DepartmentListViewModel>> GetDepartmentById(Guid id);
        ValidationResult setDepartment(DepartmentViewModel viewModel, Guid userId);
        void AddDepartment(DepartmentViewModel department ,Guid userId);
        IEnumerable<DepartmentDto> SpGetAllDepartment( string Keyword, int? pageIndex, int? pageSize);

    }
}
