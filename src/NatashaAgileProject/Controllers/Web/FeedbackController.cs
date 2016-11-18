using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//...
using NatashaAgileProject.Models;
using NatashaAgileProject.Services;
using NatashaAgileProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace NatashaAgileProject.Controllers.Web
{
    public class FeedbackController : Controller
    {
        private IFeedbackRepository _repoFeedback;
        private IPackageRepository _repoPackage;
        private UserManager<User> _userManagerService;

        public FeedbackController(IFeedbackRepository reopFeedback, UserManager<User> userManagerService, IPackageRepository repoPackage)
        {
            _repoFeedback = reopFeedback;
            _userManagerService = userManagerService;
            _repoPackage = repoPackage;
        }

        //Add Feedback
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult CreateFeedback(int id)
        {
            CreateFeedbackViewModel vm = new CreateFeedbackViewModel();
            vm.PackageId = id;
            vm.Package = _repoPackage.GetSingle(p => p.PackageId == vm.PackageId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFeedback(CreateFeedbackViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                Feedback f = new Feedback
                {
                    PackageId = vm.PackageId,
                    Description = vm.Description,
                    UserName = User.Identity.Name
                };

                //Save to DB
                _repoFeedback.Create(f);

                //Redirect to Index
                return RedirectToAction("Packages", "Package");//, new {id = vm.FeedbackId});
            }
            return View(vm);
        }

        //Display Feedback
        [HttpGet]
        [Authorize(Roles = "Customer, Provider")]
        public IActionResult DisplayFeedback(int id)
        {
            Package pac = _repoPackage.GetSingle(p => p.PackageId == id);
            if (pac == null)
            {
                return RedirectToAction("Index");
            }
            //create the vm
            DisplayFeedbackViewModel vm = new DisplayFeedbackViewModel
            {
                PacId = pac.PackageId,
                PacName = pac.PackageName,
                PacFeedback = _repoFeedback.Query(p => p.PackageId == pac.PackageId)
            };

            return View(vm);
        }
    }

}

