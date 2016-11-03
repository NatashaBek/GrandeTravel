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

    public class PackageController : Controller
    {
        public IActionResult Packages()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }

        //    private IPackageRepository _repoPackage;
        //    private IFeedbackRepository _repoFeedback;
        //    public HomeController(IPackageRepository repoPackage, IFeedbackRepository repoFeedback)
        //    {
        //        _repoPackage = repoPackage;
        //        _repoFeedback = repoFeedback;
        //    }
        //    public IActionResult Index()
        //    {
        //        //create the vm
        //        DisplayAllCategoriesViewModel vm = new DisplayAllCategoriesViewModel
        //        {
        //            Package = _repoPackage.GetAll()
        //        };

        //        return View(vm);
        //    }

        //    [HttpGet]
        //    [Authorize]
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Create(CreatePackageViewModel vm)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //map
        //            Package pac = new Package
        //            {
        //                PackageId = vm.PackageId,
        //                PackageName = vm.PackageName,
        //                Details = vm.Details,
        //                Location = vm.Location,
        //                Price = vm.Price
        //            };

        //            //save to DB
        //            _repoPackage.Create(pac);

        //            //redirect to Index
        //            return RedirectToAction("Index");
        //        }
        //        return View(vm);
        //    }

        //    public IActionResult Display(int id)
        //    {
        //        //get the category from the DB
        //        Package pac = _repoPackage.GetSingle(p => p.PackageId == id);
        //        if (pac == null)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        //create the vm
        //        DisplayPackageViewModel vm = new DisplayPackageViewModel
        //        {
        //            PackageId = pac.PackageId,
        //            PackageName = pac.PackageName,
        //            Details = pac.Details,
        //            Location = pac.Location,
        //            Price = pac.Price,
        //            PacFeedback = _repoPackage.Query(p => p.PackageId == pac.PackageId)
        //        };

        //        return View(vm);
        //    }
    }
}
