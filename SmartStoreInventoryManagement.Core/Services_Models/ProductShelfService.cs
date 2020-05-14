using SmartStoreInventoryManagement.Core.Dto;
using SmartStoreInventoryManagement.Core.EF;
using SmartStoreInventoryManagement.Core.Enums;
using SmartStoreInventoryManagement.Core.Models;
using SmartStoreInventoryManagement.Core.Reposory;
using SmartStoreInventoryManagement.Core.Services;
using SmartStoreInventoryManagement.Core.Services_Models.Interface;
using SmartStoreInventoryManagement.Core.UnitOfWork;
using SmartStoreInventoryManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Core.Services_Models
{
    public class ProductShelfService : Service<ProductShelf>, IProductShelfService
    {
        private readonly IRepository<ProductShelf> _productShelfService;

        public ProductShelfService(IRepository<ProductShelf> productShelfService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _productShelfService = productShelfService;
        }

        public void AddProductShelf(ProductShelfViewModel department, Guid userId)
        {
            if (department == null)
            {
                throw new ArgumentNullException("ProductShelf is null");
            }
            var checkitem = (ProductShelf)department;
            checkitem.CreatedBy = userId;
            this.Add(checkitem);
        }

        public async Task<List<ValidationResult>> Delete(Guid id, Guid createdBy)
        {

            try
            {
                var department = await this.GetByIdAsync(id);

                if (department == null)
                {
                    results.Add(new ValidationResult($"{id} not found"));
                    return results;
                }

                var result = await this.DeleteAsync(department);
                if (result == 0)
                {
                    results.Add(new ValidationResult($"There is an Issue deleting this Department. Kindly contact Admin"));
                    return results;
                }

                var checkId = department.Id.ToString();
                return results;
            }
            catch (Exception ex)
            {
                results.Add(new ValidationResult(ex.Message));
                return results;
            }

        }

        public async Task<List<ValidationResult>> Edit(ProductShelfEditViewModel viewModel, Guid createdBy)
        {
            try
            {
                if (viewModel == null)
                    throw new ArgumentNullException(nameof(viewModel));
                var department = await this.GetByIdAsync(Guid.Parse(viewModel.Id));

                if (department == null)
                {
                    results.Add(new ValidationResult($"{viewModel.Id} not found"));
                    return results;
                }


                department.Name = viewModel.Name;
                department.RegNumber = viewModel.RegNumber;
                department.Description = viewModel.Description;
                department.ModifiedBy = createdBy;
                department.ModifiedOn = DateTime.UtcNow;
                var createResult = await this.UpdateAsync(department);
                if (createResult == 0)
                {
                    results.Add(new ValidationResult("Update Failed"));
                    return results;
                }

                viewModel.Id = department.Id.ToString();
                return results;
            }
            catch (Exception ex)
            {
                results.Add(new ValidationResult(ex.Message));
                return results;
            }
        }

        public async Task<ApiResponse<List<ProductShelfListViewModel>>> GetAll(SearchProductShelfViewModel viewModel)
        {
            ApiResponse<List<ProductShelfListViewModel>> response = new ApiResponse<List<ProductShelfListViewModel>>();

            try
            {
                var count = UnitOfWork.Repository<ProductShelf>().Query().Count(x => !x.IsDeleted);
                Expression<Func<ProductShelf, bool>> queryPredicate = (x) => x.Name.Contains(viewModel.FilterBy)
                || x.CreatedOn >= viewModel.ToDate || x.CreatedOn <= viewModel.FromDate;

                var result = (await this.GetAllAsync(viewModel.PageIndex, viewModel.PageSize, c => c.Id, queryPredicate, OrderBy.Ascending))
                    .OrderBy(b => b.Id).Select(source => new ProductShelfListViewModel
                    {
                        Name = source.Name,
                        Description = source.Description,
                        TotalCount = count,
                        Id = source.Id.ToString(),
                    }).ToList();
                response.Payload = result;
                response.Code = ApiResponseCodes.OK;
                response.Description = ApiResponseCodes.OK.ToString();
                return response;

            }
            catch (Exception ex)
            {
                response.Payload = null;
                response.Code = ApiResponseCodes.ERROR;
                response.Description = ex.Message;
                return response;
            }
        }

        public async Task<ApiResponse<ProductShelfListViewModel>> GetById(Guid id)
        {
            ApiResponse<ProductShelfListViewModel> response = new ApiResponse<ProductShelfListViewModel>();

            try
            {
                var query = await this.GetByIdAsync(id);
                if (query == null)
                {
                    return ResponseMessage.ErrorMessage<ProductShelfListViewModel>("Record not found");
                }
                ProductShelfListViewModel details = new ProductShelfListViewModel
                {
                    Name = query.Name,
                    Description = query.Description,
                    Id = query.Id.ToString(),

                };

                return ResponseMessage.SuccessMessage("", details);

            }
            catch (Exception ex)
            {
                return ResponseMessage.ErrorMessage<ProductShelfListViewModel>(ex.Message);
            }
        }

        public async Task<List<ValidationResult>> Setup(ProductShelfViewModel viewModel, Guid userId)
        {
            try
            {
                if (viewModel == null)
                    throw new ArgumentNullException(nameof(viewModel));

                var checkitem = (ProductShelf)viewModel;
                checkitem.CreatedBy = userId;
                var createResult = await this.AddAsync(checkitem);
                return results;
            }
            catch (Exception ex)
            {
                results.Add(new ValidationResult(ex.Message));
                return results;
            }
        }

        public IEnumerable<ProductShelfDto> SpGetAllProductShelf(string Keyword, int? pageIndex, int? pageSize)
        {
            return this.UnitOfWork.Repository<ProductShelfDto>()
           .SqlQuery("Sp_GetAllProductShelf", Keyword, pageIndex, pageSize).ToList();
        }
    }
}
