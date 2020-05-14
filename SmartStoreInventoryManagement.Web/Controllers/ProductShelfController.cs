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
    public class ProductShelfController : BaseMvcController
    {
        private readonly IProductShelfService _productShelfService;
        public ProductShelfController(IProductShelfService productShelfService)
        {
            _productShelfService = productShelfService;

        }
        public IActionResult Create(SearchViewModel vm)
        {

            if (vm == null)
                vm = new SearchViewModel();
            var productShelfList = _productShelfService.SpGetAllProductShelf(vm.Keyword, vm.PageIndex, vm.PageSize);
            var dep = new List<ProductShelfViewModel>();

            foreach (var productShelf in productShelfList)
            {
                var unitOfMeasureVm = convertToVm(productShelf);
                dep.Add(unitOfMeasureVm);
            }

            var first = dep.FirstOrDefault() ?? new ProductShelfViewModel();
            var response = new StaticPagedList<ProductShelfViewModel>(dep, vm.PageIndex, vm.PageSize, first.TotalCount ?? 0);



            return View(response);
        }

        private ProductShelfViewModel convertToVm(ProductShelfDto dep)
        {
            return new ProductShelfViewModel
            {
                Id = dep.Id,
                Name = dep.Name,
                RegNumber = dep.RegNumber,
                Description = dep.Description,
                TotalCount = dep.TotalCount
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductShelfViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var depart = new ProductShelf
                    {

                        // Id = viewModel.Created_Id,
                        Name = viewModel.Name,
                        RegNumber = viewModel.RegNumber,
                        Description = viewModel.Description,
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
                    _productShelfService.AddProductShelf(viewModel, this.CurrentUser.UserId);


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
        public ActionResult EditProductShelf(Guid id)
        {

            var dep = _productShelfService.Find(id);

            if (dep == null)
            {
                ErrorNotification("The selected location was not found ");
                return RedirectToAction("Create");
            }
            return View(dep);
        }

        [HttpPost]
        public ActionResult EditProductShelf(ProductShelf dvm)
        {
            //if (!_permissionSvc.TryCheckAccess(StandardPermissionProvider.ManageDepartment, CurrentUser))
            //{
            //    return AccessDeniedView();
            //}
            var dept = _productShelfService.Find(dvm.Id);
            if (dept == null)
            {
                ErrorNotification("Category could not be found or has been deleted");
                return RedirectToAction("Create ");
            }

            if (ModelState.IsValid)
            {
                dept.RegNumber = dvm.RegNumber;
                dept.Name = dvm.Name;
                dept.Description = dvm.Description;
                _productShelfService.Update(dept);

                SuccessNotification("Category updated Successfully");
                return RedirectToAction("EditProductShelf");
            }
            return View();
        }

    }
}
