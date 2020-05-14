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
    public class CategoryController: BaseMvcController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public IActionResult Create(SearchViewModel vm)
        {

            if (vm == null)
                vm = new SearchViewModel();
            var categoryList = _categoryService.SpGetAllCategory(vm.Keyword, vm.PageIndex, vm.PageSize);
            var dep = new List<CategoryViewModel>();

            foreach (var category in categoryList)
            {
                var locationVm = convertToVm(category);
                dep.Add(locationVm);
            }

            var first = dep.FirstOrDefault() ?? new CategoryViewModel();
            var response = new StaticPagedList<CategoryViewModel>(dep, vm.PageIndex, vm.PageSize, first.TotalCount ?? 0);



            return View(response);
        }

        private CategoryViewModel convertToVm(CategoryDto dep)
        {
            return new CategoryViewModel
            {
                Id = dep.Id,
                Name = dep.Name,
                CategoryNo = dep.CategorNumber,
                Description = dep.Description,
                TotalCount = dep.TotalCount
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var depart = new Category
                    {

                        // Id = viewModel.Created_Id,
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        CategorNumber = viewModel.CategoryNo,
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
                    _categoryService.AddDepartment(viewModel, this.CurrentUser.UserId);


                    SuccessNotification("Department Created  successfully");
                    return RedirectToAction(nameof(Create));
                }
                return RedirectToAction(nameof(Create));// TODO: Add insert logic here

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return View();
            }
        }



        [HttpGet]
        public ActionResult EditCategory(Guid id)
        {

            var dep = _categoryService.Find(id);

            if (dep == null)
            {
                ErrorNotification("The selected location was not found ");
                return RedirectToAction("Create");
            }
            return View(dep);
        }

        [HttpPost]
        public ActionResult EditCategory(Category dvm)
        {
            //if (!_permissionSvc.TryCheckAccess(StandardPermissionProvider.ManageDepartment, CurrentUser))
            //{
            //    return AccessDeniedView();
            //}
            var dept = _categoryService.Find(dvm.Id);
            if (dept == null)
            {
                ErrorNotification("Category could not be found or has been deleted");
                return RedirectToAction("Department");
            }

            if (ModelState.IsValid)
            {
                dept.CategorNumber = dvm.CategorNumber;
                dept.Name = dvm.Name;
                dept.Description = dvm.Description;
                _categoryService.Update(dept);

                SuccessNotification("Category updated Successfully");
                return RedirectToAction("Category");
            }
            return View();
        }
    }
}
