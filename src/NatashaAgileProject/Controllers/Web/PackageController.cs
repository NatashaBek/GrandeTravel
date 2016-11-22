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
        private IPackageRepository _repoPackage;
        private IFeedbackRepository _repoFeedback;

        public PackageController(IPackageRepository repoPackage, IFeedbackRepository repoFeedback)
        {
            _repoPackage = repoPackage;
            _repoFeedback = repoFeedback;
        }

        //Return all Available Packages
        [HttpGet]
        public IActionResult Packages()
        {
            //Create the vm
            DisplayAllPackagesViewModel vm = new DisplayAllPackagesViewModel
            {
                //Packages = _repoPackage.GetAll()
                Packages = _repoPackage.Query(p => p.Availability == true)               
            };

            return View(vm);
        }

        //Create a new Package
        [HttpGet]
        [Authorize(Roles = "Provider")]
        public IActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Manage(CreatePackageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                Package pac = new Package
                {
                    PackageName = vm.PackageName,
                    Details = vm.Details,
                    Location = vm.Location,
                    Price = vm.Price,
                    Availability = vm.Availability
                };

                //Save the Package to DB
                _repoPackage.Create(pac);

                //Redirect to Packages
                return RedirectToAction("Packages");
            }
            return View(vm);
        }

        //Update Package Details
        [HttpGet]
        [Authorize(Roles = "Provider")]
        public IActionResult UpdatePackages(int id)
        {
            //Get the Package from the DB
            Package pac = _repoPackage.GetSingle(p => p.PackageId == id);
            if (pac == null)
            {
                return RedirectToAction("Index");
            }

            //Create the vm
            UpdatePackageDetailsViewModel vm = new UpdatePackageDetailsViewModel
            {
                Details = pac.Details,
                Location = pac.Location,
                Price = pac.Price,
                Availability = pac.Availability
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePackages(int id, UpdatePackageDetailsViewModel vm)
        {
            Package pac = _repoPackage.GetSingle(p => p.PackageId == id);
            if (pac != null && ModelState.IsValid)
            {
                pac.Details = vm.Details;
                pac.Location = vm.Location;
                pac.Price = vm.Price;
                pac.Availability = vm.Availability;

                //Save the updated Package to DB
                _repoPackage.Update(pac);

                //Redirect to Packages
                return RedirectToAction("Packages");
            }
            return View(vm);
        }


        //Search for Packages
        [HttpGet]
        public IActionResult Search()
        {
            SearchPackageViewModel vm = new SearchPackageViewModel
            {
                Packages = _repoPackage.GetAll()
                //Packages = _repoPackage.Query(p => p.Availability == true)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(SearchPackageViewModel vm, string location)
        {
            if (ModelState.IsValid)
            {
                vm.Packages = _repoPackage.Query(p => p.Location == location);
            }
            return View(vm);
        }

        //Filter Search
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult FilterSearch()
        //{
        //    return View(vm);
        //}


        //Return Angular Page
        [HttpGet]
        public IActionResult Angular()
        {
            return View();
        }
    }
}
   
