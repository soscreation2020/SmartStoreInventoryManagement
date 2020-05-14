using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using SmartStoreInventoryManagement.Core.AspNetCore;
using SmartStoreInventoryManagement.Core.Dto;
using SmartStoreInventoryManagement.Core.Models;
using SmartStoreInventoryManagement.Core.Services_Models.Interface;
using SmartStoreInventoryManagement.Core.ViewModel;

namespace SmartStoreInventoryManagement.Web.Controllers
{
    public class DepartmentController : BaseMvcController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;

        }
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditDepartment(Guid id)
        {
            
            var dep = _departmentService.Find(id);

            if (dep == null)
            {
                ErrorNotification("The selected location was not found ");
                return RedirectToAction("Create");
            }
            return View(dep);
        }

        [HttpPost]
        public ActionResult EditDepartment(Department dvm)
        {
            //if (!_permissionSvc.TryCheckAccess(StandardPermissionProvider.ManageDepartment, CurrentUser))
            //{
            //    return AccessDeniedView();
            //}
            var dept = _departmentService.Find(dvm.Id);
            if (dept == null)
            {
                ErrorNotification("Department could not be found or has been deleted");
                return RedirectToAction("Department");
            }

            if (ModelState.IsValid)
            {
                dept.RegNumber = dvm.RegNumber;
                dept.Name = dvm.Name;
                dept.Description = dvm.Description;
                _departmentService.Update(dept);
               
                SuccessNotification("Department updated Successfully");
                return RedirectToAction("Department");
            }
            return View();
        }
        // GET: Department/Create
        public IActionResult Create(SearchViewModel vm)
        {

            if (vm == null)
                vm = new SearchViewModel();
            var departmentList =_departmentService.SpGetAllDepartment(vm.Keyword, vm.PageIndex, vm.PageSize);
            var dep = new List<DepartmentViewModel>();

            foreach (var location in departmentList)
            {
                var locationVm = convertToVm(location);
                dep.Add(locationVm);
            }

            var first = dep.FirstOrDefault() ?? new DepartmentViewModel();
            var response = new StaticPagedList<DepartmentViewModel>(dep, vm.PageIndex, vm.PageSize, first.TotalCount ?? 0);



            return View(response);
        }

        private DepartmentViewModel convertToVm(DepartmentDto dep)
        {
            return new DepartmentViewModel
            {
                Id=dep.Id,
                Name = dep.Name,
                RegNumber = dep.RegNumber,
                Description = dep.Description,
                TotalCount = dep.TotalCount
            };
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var depart = new Department
                    {

                      // Id = viewModel.Created_Id,
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        RegNumber = viewModel.RegNumber,
                        CreatedBy = CurrentUser.UserId,
                        CreatedOn = DateTime.Now,
                        CreateOn= DateTime.Now,

                    };
                    //var reg = _departmentService.Find(t => t.RegNumber.Equals(departsVm.RegNumber), false);
                    //if (reg != null)
                    //{
                    //    ErrorNotification("Department with this number already exists");
                    //    return RedirectToAction("Department");
                    //}
                    _departmentService.AddDepartment(viewModel, this.CurrentUser.UserId);


                    SuccessNotification("Department Created  successfully");

                }
                return RedirectToAction(nameof(Create));// TODO: Add insert logic here

            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Department/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}