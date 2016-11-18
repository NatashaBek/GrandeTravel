using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//...
using NatashaAgileProject.Models;
using NatashaAgileProject.Services;
using NatashaAgileProject.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace NatashaAgileProject.Controllers.Web
{
    public class OrderController : Controller
    {
        private IOrderRepository _repoOrder;
        private IPackageRepository _repoPackage;

        public OrderController(IOrderRepository repoOrder, IPackageRepository repoPackage)
        {
            _repoOrder = repoOrder;
            _repoPackage = repoPackage;
        }

        //Order Package
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult OrderPackage(int id)
        {
            AddOrderViewModel vm = new AddOrderViewModel();
            vm.PackageId = id;
            vm.Packages = _repoPackage.GetSingle(p => p.PackageId == vm.PackageId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public IActionResult OrderPackage(AddOrderViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                Order o = new Order
                {
                    Date = DateTime.Now,
                    PackageName = vm.PackageName,
                    PackageId = vm.PackageId,
                    UserName = vm.UserName
                };

                //Save to DB
                _repoOrder.Create(o);

                //Redirect to Index
                return RedirectToAction("Packages", "Package");
            }
            return View(vm);
        }
    }
}
