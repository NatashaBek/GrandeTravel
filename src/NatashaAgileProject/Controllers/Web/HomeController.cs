using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//...
using NatashaAgileProject.Services;
using NatashaAgileProject.Models;
using NatashaAgileProject.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace NatashaAgileProject.Controllers.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
