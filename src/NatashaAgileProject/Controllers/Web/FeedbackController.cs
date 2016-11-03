using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//...
using NatashaAgileProject.Models;
using NatashaAgileProject.Services;
using NatashaAgileProject.ViewModels;


namespace NatashaAgileProject.Controllers.Web
{
    public class FeedbackController : Controller
    {
        private IFeedbackRepository _reopFeedback;

        public FeedbackController(IFeedbackRepository reopFeedback)
        {
            _reopFeedback = reopFeedback;
        }

        //Add Feedback
        [HttpGet]
        public IActionResult Add(int id)
        {
            CreateFeedbackViewModel vm = new CreateFeedbackViewModel
            {
                FeedbackId = id
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreateFeedbackViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                Feedback f = new Feedback
                {
                    FeedbackId = vm.FeedbackId,
                    Description = vm.Description
                };

                //Save to DB
                _reopFeedback.Create(f);

                //Redirect to Index
                return RedirectToAction("Index", "Home", new { id = vm.FeedbackId });
            }
            return View(vm);
        }
    }
}
