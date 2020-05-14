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
    public class UnitOfMeasureController : BaseMvcController
    {
        private readonly IUnitOfMeasureService _unitOfMeasureService;
        public UnitOfMeasureController(IUnitOfMeasureService unitOfMeasureService)
        {
            _unitOfMeasureService = unitOfMeasureService;

        }

        public IActionResult Create(SearchViewModel vm)
        {

            if (vm == null)
                vm = new SearchViewModel();
            var unitOfMeasureList = _unitOfMeasureService.SpGetAllUnitOfMeasure(vm.Keyword, vm.PageIndex, vm.PageSize);
            var dep = new List<UnitOfMeasureViewModel>();

            foreach (var unitOfMeasure in unitOfMeasureList)
            {
                var unitOfMeasureVm = convertToVm(unitOfMeasure);
                dep.Add(unitOfMeasureVm);
            }

            var first = dep.FirstOrDefault() ?? new UnitOfMeasureViewModel();
            var response = new StaticPagedList<UnitOfMeasureViewModel>(dep, vm.PageIndex, vm.PageSize, first.TotalCount ?? 0);



            return View(response);
        }

        private UnitOfMeasureViewModel convertToVm(UnitOfMeasureDto dep)
        {
            return new UnitOfMeasureViewModel
            {
                Id = dep.Id,
                Name = dep.Name,
                Symbol = dep.Symbol,
                Decimals = dep.Decimals,
                TotalCount = dep.TotalCount
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UnitOfMeasureViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var depart = new UnitOfMeasure
                    {

                        // Id = viewModel.Created_Id,
                        Name = viewModel.Name,
                        Symbol = viewModel.Symbol,
                        Decimals = viewModel.Decimals,
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
                    _unitOfMeasureService.AddUnitOfMeasure(viewModel, this.CurrentUser.UserId);


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
        public ActionResult EditUnitOfMeasure(Guid id)
        {

            var dep = _unitOfMeasureService.Find(id);

            if (dep == null)
            {
                ErrorNotification("The selected location was not found ");
                return RedirectToAction("Create");
            }
            return View(dep);
        }

        [HttpPost]
        public ActionResult EditUnitOfMeasure(UnitOfMeasure dvm)
        {
            //if (!_permissionSvc.TryCheckAccess(StandardPermissionProvider.ManageDepartment, CurrentUser))
            //{
            //    return AccessDeniedView();
            //}
            var dept = _unitOfMeasureService.Find(dvm.Id);
            if (dept == null)
            {
                ErrorNotification("Category could not be found or has been deleted");
                return RedirectToAction("Department");
            }

            if (ModelState.IsValid)
            {
                dept.Symbol = dvm.Symbol;
                dept.Name = dvm.Name;
                dept.Decimals = dvm.Decimals;
                _unitOfMeasureService.Update(dept);

                SuccessNotification("Category updated Successfully");
                return RedirectToAction("Category");
            }
            return View();
        }

    }
}
