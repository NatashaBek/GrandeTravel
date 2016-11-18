using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//...
using NatashaAgileProject.Services;

//Test in Postman
namespace NatashaAgileProject.Controllers.Api
{    
    [Route ("api/package")]
    public class ApiController : Controller
    {
        private IPackageRepository _repoPackage;

        public ApiController(IPackageRepository repoPackage)
        {
            _repoPackage = repoPackage;
        }

        //Add Availability
        [HttpGet("allpackages")]
        public JsonResult GetAllPackages()
        {
            var packages = _repoPackage.GetAll();

            return Json(packages);
        }

        [HttpGet("location")]
        public JsonResult GetLocation(string loc)
        {
            var location = _repoPackage.Query(p => p.Location == loc);
            return Json(location);
        }

    }
}
