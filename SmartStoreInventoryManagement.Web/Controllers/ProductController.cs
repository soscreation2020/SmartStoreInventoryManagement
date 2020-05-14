using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using SmartStoreInventoryManagement.Core.AspNetCore;
using SmartStoreInventoryManagement.Core.Dto;
using SmartStoreInventoryManagement.Core.Models;
using SmartStoreInventoryManagement.Core.Services_Models.Interface;
using SmartStoreInventoryManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStoreInventoryManagement.Web.Controllers
{
    public class ProductController : BaseMvcController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }


        public IActionResult Create(SearchViewModel vm)
        {

            if (vm == null)
                vm = new SearchViewModel();
            var productShelfList = _productService.SpGetAllProduct(vm.Keyword, vm.PageIndex, vm.PageSize);
            var dep = new List<ProductViewModel>();

            foreach (var productShelf in productShelfList)
            {
                var unitOfMeasureVm = convertToVm(productShelf);
                dep.Add(unitOfMeasureVm);
            }

            var first = dep.FirstOrDefault() ?? new ProductViewModel();
            var response = new StaticPagedList<ProductViewModel>(dep, vm.PageIndex, vm.PageSize, first.TotalCount ?? 0);



            return View(response);
        }

        private ProductViewModel convertToVm(ProductDto dep)
        {
            return new ProductViewModel
            {
                Id = dep.Id,
                Name = dep.Name,
                ProductNo = dep.ProductNo,
                Description = dep.Description,
                UnitCost=dep.UnitCost,
                UnitPrice=dep.UnitPrice,
                StockOutWarning=dep.StockOutWarning,
                TotalCount = dep.TotalCount
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var depart = new Product
                    {

                        // Id = viewModel.Created_Id,
                        Name = viewModel.Name,
                        ProductNo = viewModel.ProductNo,
                        Description = viewModel.Description,
                        TagNumber=viewModel.TagNumber,
                        SerialNumber = viewModel.SerialNumber,
                        Period = viewModel.Period,
                        ReasonForInactivity = viewModel.ReasonForInactivity,
                        Active = viewModel.Active,
                        RFID = viewModel.RFID,
                        Barcode = viewModel.Barcode,
                        Class = viewModel.Class,
                        Style = viewModel.Style,
                        Color = viewModel.Color,
                        OpenBalance = viewModel.OpenBalance,
                        StandardCost = viewModel.StandardCost,
                        UnitCost = viewModel.UnitCost,
                        UnitPrice = viewModel.UnitPrice,
                        StockOutWarning = viewModel.StockOutWarning,
                        ReOrderPoint = viewModel.ReOrderPoint,
                        SellStartDate = viewModel.SellStartDate,
                        SellEndDate = viewModel.SellEndDate,
                        DiscountRate = viewModel.DiscountRate,
                        VATRate = viewModel.VATRate,
                        Category_Id = viewModel.Category_Id,
                        ProductShelf_Id=viewModel.ProductShelf_Id,
                        Staff_Id= CurrentUser.UserId,
                        UnitOfMeasure_Id=viewModel.UnitOfMeasure_Id,
                        CreatedBy = CurrentUser.UserId,
                        CreatedOn = DateTime.Now,
                        CreateOn = DateTime.Now,

                    };
                    //var reg = _departmentService.Find(t => t.RegNumber.Equals(departsVm.RegNumber), false);
                    //if (reg != null)
                    //{
                    //    ErrorNotification("Department with this number already exists");
                    //    return RedirectToAction("Department");
                    //}
                    _productService.AddProduct(viewModel, this.CurrentUser.UserId);


                    SuccessNotification("Department Created  successfully");
                    return RedirectToAction(nameof(Create));
                }
                return RedirectToAction(nameof(Create));// TODO: Add insert logic here

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return View();
            }
        }



        [HttpGet]
        public ActionResult EditProduct(Guid id)
        {

            var dep = _productService.Find(id);

            if (dep == null)
            {
                ErrorNotification("The selected location was not found ");
                return RedirectToAction("Create");
            }
            return View(dep);
        }

        [HttpPost]
        public ActionResult EditProduct(Product dvm)
        {
            //if (!_permissionSvc.TryCheckAccess(StandardPermissionProvider.ManageDepartment, CurrentUser))
            //{
            //    return AccessDeniedView();
            //}
            var dept = _productService.Find(dvm.Id);
            if (dept == null)
            {
                ErrorNotification("Category could not be found or has been deleted");
                return RedirectToAction("Department");
            }

            if (ModelState.IsValid)
            {

                dept.ProductNo = dvm.ProductNo;
                dept.Name = dvm.Name;
                dept.Description = dvm.Description;
                dept.TagNumber = dvm.TagNumber;
                dept.SerialNumber = dvm.SerialNumber;
                dept.Period = dvm.Period;
                dept.ReasonForInactivity = dvm.ReasonForInactivity;
                dept.Active = dvm.Active;
                dept.RFID = dvm.RFID;
                dept.Barcode = dvm.Barcode;
                dept.Class = dvm.Class;
                dept.Style = dvm.Style;
                dept.Color = dvm.Color;
                dept.OpenBalance = dvm.OpenBalance;
                dept.StandardCost = dvm.StandardCost;
                dept.UnitCost = dvm.UnitCost;
                dept.UnitPrice = dvm.UnitPrice;
                dept.StockOutWarning = dvm.StockOutWarning;
                dept.ReOrderPoint = dvm.ReOrderPoint;
                dept.SellStartDate = dvm.SellStartDate;
                dept.SellEndDate = dvm.SellEndDate;
                dept.DiscountRate = dvm.DiscountRate;
                dept.VATRate = dvm.VATRate;
                dept.Category_Id = dvm.Category_Id;
                dept.ProductShelf_Id = dvm.ProductShelf_Id;
                dept.Staff_Id = CurrentUser.UserId;
                dept.UnitOfMeasure_Id = dvm.UnitOfMeasure_Id;
                dept.CreatedBy = CurrentUser.UserId;
                dept.CreatedOn = DateTime.Now;
                dept.CreateOn = DateTime.Now;
               
                _productService.Update(dept);

                SuccessNotification("Category updated Successfully");
                return RedirectToAction("Category");
            }
            return View();
        }
    }
}
