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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IRepository<Product> _productService;

        public ProductService(IRepository<Product> productService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _productService = productService;
        }

        public void AddProduct(ProductViewModel department, Guid userId)
        {
            if (department == null)
            {
                throw new ArgumentNullException("ProductShelf is null");
            }
            var checkitem = (Product)department;
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

        public async Task<List<ValidationResult>> Edit(ProductEditViewModel viewModel, Guid createdBy)
        {
            try
            {
                if (viewModel == null)
                    throw new ArgumentNullException(nameof(viewModel));
                var product = await this.GetByIdAsync(Guid.Parse(viewModel.Id));

                if (product == null)
                {
                    results.Add(new ValidationResult($"{viewModel.Id} not found"));
                    return results;
                }


                product.Name = viewModel.Name;
                product.ProductNo = viewModel.ProductNo;
                product.Active = viewModel.Active;
                product.Barcode = viewModel.Barcode;
                product.VATRate = viewModel.VATRate;
                product.Class = viewModel.Class;
                product.Color = viewModel.Color;
                product.Category_Id = viewModel.Category_Id;
                product.StandardCost = viewModel.StandardCost;
                product.productstatus = viewModel.productstatus;
                product.productType = viewModel.productType;
                product.Period = viewModel.Period;
                product.ReOrderPoint = viewModel.ReOrderPoint;
                product.ReasonForInactivity = viewModel.ReasonForInactivity;
                product.TagNumber = viewModel.TagNumber;
                product.DiscountRate = viewModel.DiscountRate;
                product.OpenBalance = viewModel.OpenBalance;
                product.RFID = viewModel.RFID;
                product.UnitPrice = viewModel.UnitPrice;
                product.UnitOfMeasure_Id = viewModel.UnitOfMeasure_Id;
                product.Description = viewModel.Description;
                product.Staff_Id = viewModel.Staff_Id;
                product.StandardCost = viewModel.StandardCost;
                product.Style = viewModel.Style;
                product.SellStartDate = viewModel.SellStartDate;
                product.SerialNumber = viewModel.SerialNumber;
                product.StockOutWarning = viewModel.StockOutWarning;
                product.ProductShelf_Id = viewModel.ProductShelf_Id;
                product.ModifiedBy = createdBy;
                product.ModifiedOn = DateTime.UtcNow;
                var createResult = await this.UpdateAsync(product);
                if (createResult == 0)
                {
                    results.Add(new ValidationResult("Update Failed"));
                    return results;
                }

                viewModel.Id = product.Id.ToString();
                return results;
            }
            catch (Exception ex)
            {
                results.Add(new ValidationResult(ex.Message));
                return results;
            }
        }

        public async Task<ApiResponse<List<ProductListViewModel>>> GetAll(SearchProductViewModel viewModel)
        {
            ApiResponse<List<ProductListViewModel>> response = new ApiResponse<List<ProductListViewModel>>();

            try
            {
                var count = UnitOfWork.Repository<Product>().Query().Count(x => !x.IsDeleted);
                Expression<Func<Product, bool>> queryPredicate = (x) => x.Name.Contains(viewModel.FilterBy)
                || x.CreatedOn >= viewModel.ToDate || x.CreatedOn <= viewModel.FromDate;

                var result = (await this.GetAllAsync(viewModel.PageIndex, viewModel.PageSize, c => c.Id, queryPredicate, OrderBy.Ascending))
                    .OrderBy(b => b.Id).Select(source => new ProductListViewModel
                    {
                        Name = source.Name,
                        ProductNo = source.ProductNo,
                        Active = source.Active,
                        Barcode = source.Barcode,
                        VATRate = source.VATRate,
                        Class = source.Class,
                        Color = source.Color,
                        Category_Id = source.Category_Id,
                        StandardCost = source.StandardCost,
                        productstatus = source.productstatus,
                        productType = source.productType,
                        Period = source.Period,
                        ReOrderPoint = source.ReOrderPoint,
                        ReasonForInactivity = source.ReasonForInactivity,
                        TagNumber = source.TagNumber,
                        DiscountRate = source.DiscountRate,
                        OpenBalance = source.OpenBalance,
                        RFID = source.RFID,
                        UnitPrice = source.UnitPrice,
                        UnitOfMeasure_Id = source.UnitOfMeasure_Id,
                        Description = source.Description,
                        Staff_Id = source.Staff_Id,
                        Style = source.Style,
                        SellStartDate = source.SellStartDate,
                        SerialNumber = source.SerialNumber,
                        StockOutWarning = source.StockOutWarning,
                        ProductShelf_Id=source.ProductShelf_Id,
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



        public async Task<ApiResponse<ProductListViewModel>> GetById(Guid id)
        {
            ApiResponse<ProductListViewModel> response = new ApiResponse<ProductListViewModel>();

            try
            {
                var query = await this.GetByIdAsync(id);
                if (query == null)
                {
                    return ResponseMessage.ErrorMessage<ProductListViewModel>("Record not found");
                }
                ProductListViewModel details = new ProductListViewModel
                {
                    Name = query.Name,
                    ProductNo = query.ProductNo,
                    Active = query.Active,
                    Barcode = query.Barcode,
                    VATRate = query.VATRate,
                    Class = query.Class,
                    Color = query.Color,
                    Category_Id = query.Category_Id,
                    StandardCost = query.StandardCost,
                    productstatus = query.productstatus,
                    productType = query.productType,
                    Period = query.Period,
                    ReOrderPoint = query.ReOrderPoint,
                    ReasonForInactivity = query.ReasonForInactivity,
                    TagNumber = query.TagNumber,
                    DiscountRate = query.DiscountRate,
                    OpenBalance = query.OpenBalance,
                    RFID = query.RFID,
                    UnitPrice = query.UnitPrice,
                    UnitOfMeasure_Id = query.UnitOfMeasure_Id,
                    Description = query.Description,
                    Staff_Id = query.Staff_Id,
                    Style = query.Style,
                    SellStartDate = query.SellStartDate,
                    SerialNumber = query.SerialNumber,
                    StockOutWarning = query.StockOutWarning,
                    ProductShelf_Id=query.ProductShelf_Id,
                    Id = query.Id.ToString(),

                };

                return ResponseMessage.SuccessMessage("", details);

            }
            catch (Exception ex)
            {
                return ResponseMessage.ErrorMessage<ProductListViewModel>(ex.Message);
            }
        }

        public async Task<List<ValidationResult>> Setup(ProductViewModel viewModel, Guid userId)
        {
            try
            {
                if (viewModel == null)
                    throw new ArgumentNullException(nameof(viewModel));

                var checkitem = (Product)viewModel;
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

        public IEnumerable<ProductDto> SpGetAllProduct(string Keyword, int? pageIndex, int? pageSize)
        {

            return this.UnitOfWork.Repository<ProductDto>()
           .SqlQuery("Sp_GetAllProduct", Keyword, pageIndex, pageSize).ToList();
        }
    }
}
