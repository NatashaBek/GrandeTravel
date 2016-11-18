using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; //Threading is active when using async & await
using Microsoft.AspNetCore.Mvc;
//...
using NatashaAgileProject.Services;
using NatashaAgileProject.Models;
using NatashaAgileProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace NatashaAgileProject.Controllers.Web
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManagerService;
        private SignInManager<User> _signinManagerService;
        private RoleManager<IdentityRole> _roleManagerService;

        public AccountController(UserManager<User> userManagerService, SignInManager<User> signinManagerService, RoleManager<IdentityRole> roleManagerService)
        {
            _userManagerService = userManagerService;
            _signinManagerService = signinManagerService;
            _roleManagerService = roleManagerService;
        }
        
        //Register Customer
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {             
                if (ModelState.IsValid)
            {
                //Mapping 
                User user = new User
                {
                    UserName = vm.UserName,
                    Email = vm.Email
                };

                //Add the user to the DB (method hashes the password)
                var result = await _userManagerService.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    if (!await _userManagerService.IsInRoleAsync(user, "Customer"))
                    {
                        await _userManagerService.AddToRoleAsync(user, "Customer");
                    }
                    
                    //Redirect to the HomePage
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        //Report Error
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View(vm);
        }

        //Register Provider
        [HttpGet]
        public IActionResult RegisterProvider()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterProvider(RegisterViewModel vm)
        {          
            if (ModelState.IsValid)
            {
                //Mapping 
                User user = new User
                {
                    UserName = vm.UserName,
                    Email = vm.Email
                };

                //Add the user to the DB (method hashes the password)
                var result = await _userManagerService.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    if (!await _userManagerService.IsInRoleAsync(user, "Provider"))
                    {
                        await _userManagerService.AddToRoleAsync(user, "Provider");
                    }

                    //Redirect to the HomePage
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        //Report Error
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View(vm);
        }

        //Login
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            LoginViewModel vm = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManagerService.PasswordSignInAsync(vm.UserName, vm.Password, false, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(vm.ReturnUrl) && Url.IsLocalUrl(vm.ReturnUrl))
                    {
                        return Redirect(vm.ReturnUrl);
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Username or Password is Incorrect");
            return View(vm);
        }

        //Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signinManagerService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //Update User Details
        [HttpGet]
        [Authorize(Roles = "Customer, Provider")]
        public async Task<IActionResult> UpdateUser()
        {
            //find the User with id
            User u = await _userManagerService.GetUserAsync(HttpContext.User);

            //mapping from m to vm
            UpdateUserViewModel vm = new UpdateUserViewModel
            {
                UserName = u.UserName,
                Email = u.Email,
            };

            //pass it to the view
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel vm)
        {
            User u = await _userManagerService.GetUserAsync(HttpContext.User);

            if (u != null && ModelState.IsValid)
            {
                //Mapping-updating from vm to m
                u.UserName = vm.UserName;
                u.Email = vm.Email;

                //update the Users Details
                await _userManagerService.UpdateAsync(u);
                
                //Return to Index
                return RedirectToAction("Index", "Home");
            }
            return View(vm);
        }

        //Add Roles
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(RoleViewModel vm)
        {
            var theRole = await _roleManagerService.FindByNameAsync(vm.RoleName);

            if (theRole == null)
            {
                await _roleManagerService.CreateAsync(new IdentityRole(vm.RoleName));
            }
            return RedirectToAction("Roles");
        }

        //Add User to Roles
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserToRole(User user, string roleName)
        {
            if (!await _userManagerService.IsInRoleAsync(user, roleName))
            {
                await _userManagerService.AddToRoleAsync(user, roleName);
            }
            return Ok();
        }

        //Display User
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            var UsersContext = new ProjectDbContext();
            List<User> list = UsersContext.Users.ToList();

            //create the vm
            DisplayUserViewModel vm = new DisplayUserViewModel
            {
                Users = list
            };

            return View(vm);
        }

        //Display Role
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Roles()
        {
            var UsersContext = new ProjectDbContext();
            List<IdentityRole> list = UsersContext.Roles.ToList();

            //create the vm
            DisplayRoleViewModel vm = new DisplayRoleViewModel
            {
                Roles = list
            };

            return View(vm);
        }

        //Authorization Restriction
        //[HttpGet]
        //public IActionResult Denied()
        //{
        //    return View();
        //}
    }
}
