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
    public class UnitOfMeasureService : Service<UnitOfMeasure>, IUnitOfMeasureService
    {
        private readonly IRepository<UnitOfMeasure> _unitOfMeasureService;
        public UnitOfMeasureService(IRepository<UnitOfMeasure> unitOfMeasureService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfMeasureService = unitOfMeasureService;
        }
        public async Task<List<ValidationResult>> SetupUnitOfMeasure(UnitOfMeasureViewModel viewModel, Guid userId)
        {
            try
            {
                if (viewModel == null)
                    throw new ArgumentNullException(nameof(viewModel));

                var checkitem = (UnitOfMeasure)viewModel;
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
        public async Task<List<ValidationResult>> DeleteUnitOfMeasure(Guid id, Guid createdBy)
        {
            try
            {
                var unitOfMeasure = await this.GetByIdAsync(id);

                if (unitOfMeasure == null)
                {
                    results.Add(new ValidationResult($"{id} not found"));
                    return results;
                }

                var result = await this.DeleteAsync(unitOfMeasure);
                if (result == 0)
                {
                    results.Add(new ValidationResult($"There is an Issue deleting this Department. Kindly contact Admin"));
                    return results;
                }

                var checkId = unitOfMeasure.Id.ToString();
                return results;
            }catch (Exception ex)
            {
                results.Add(new ValidationResult(ex.Message));
                return results;
            } 
        }

        public async Task<List<ValidationResult>> EditUnitOfMeasure(UnitOfMeasureEditViewModel viewModel, Guid createdBy)
        {
            try
            {
                if (viewModel == null)
                    throw new ArgumentNullException(nameof(viewModel));
                var unitOfMeasure = await this.GetByIdAsync(Guid.Parse(viewModel.Id));

                if (unitOfMeasure == null)
                {
                    results.Add(new ValidationResult($"{viewModel.Id} not found"));
                    return results;
                }


                unitOfMeasure.Symbol = viewModel.Symbol;
                unitOfMeasure.Name = viewModel.Name;
                unitOfMeasure.Decimals = viewModel.Decimals;
                unitOfMeasure.ModifiedBy = createdBy;
                unitOfMeasure.ModifiedOn = DateTime.UtcNow;
                var createResult = await this.UpdateAsync(unitOfMeasure);
                if (createResult == 0)
                {
                    results.Add(new ValidationResult("Update Failed"));
                    return results;
                }

                viewModel.Id = unitOfMeasure.Id.ToString();
                return results;
            }
            catch (Exception ex)
            {
                results.Add(new ValidationResult(ex.Message));
                return results;
            }
        }

        public async Task<ApiResponse<List<UnitOfMeasureListViewModel>>> GetAllUnitOfMeasure(SearchUnitOfMeasureViewModel viewModel)
        {
            ApiResponse<List<UnitOfMeasureListViewModel>> response = new ApiResponse<List<UnitOfMeasureListViewModel>>();

            try
            {
                var count = UnitOfWork.Repository<UnitOfMeasure>().Query().Count(x => !x.IsDeleted);
                Expression<Func<UnitOfMeasure, bool>> queryPredicate = (x) => x.Name.Contains(viewModel.FilterBy)
                || x.CreatedOn >= viewModel.ToDate || x.CreatedOn <= viewModel.FromDate;

                var result = (await this.GetAllAsync(viewModel.PageIndex, viewModel.PageSize, c => c.Id, queryPredicate, OrderBy.Ascending))
                    .OrderBy(b => b.Id).Select(source => new UnitOfMeasureListViewModel
                    {
                        Name = source.Name,
                        Symbol = source.Symbol,
                        Decimals=source.Decimals,
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

        public async Task<ApiResponse<UnitOfMeasureListViewModel>> GetUnitOfMeasureById(Guid id)
        {
            ApiResponse<UnitOfMeasureListViewModel> response = new ApiResponse<UnitOfMeasureListViewModel>();

            try
            {
                var query = await this.GetByIdAsync(id);
                if (query == null)
                {
                    return ResponseMessage.ErrorMessage<UnitOfMeasureListViewModel>("Record not found");
                }
                UnitOfMeasureListViewModel details = new UnitOfMeasureListViewModel
                {
                    Name = query.Name,
                    Symbol = query.Symbol,
                    Decimals=query.Decimals,
                    Id = query.Id.ToString(),

                };

                return ResponseMessage.SuccessMessage("", details);

            }
            catch (Exception ex)
            {
                return ResponseMessage.ErrorMessage<UnitOfMeasureListViewModel>(ex.Message);
            }
        }

        public void AddUnitOfMeasure(UnitOfMeasureViewModel department, Guid userId)
        {
            if (department == null)
            {
                throw new ArgumentNullException("department is null");
            }
            var checkitem = (UnitOfMeasure)department;
            checkitem.CreatedBy = userId;
            this.Add(checkitem);
        }

        public IEnumerable<UnitOfMeasureDto> SpGetAllUnitOfMeasure(string Keyword, int? pageIndex, int? pageSize)
        {
            return this.UnitOfWork.Repository<UnitOfMeasureDto>()
            .SqlQuery("Sp_GetAllUnitOfMeasure", Keyword, pageIndex, pageSize).ToList();
        }
    }
}
