using JobListing.Data;
using JobListing.Models;
using JobListing.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext _db;


        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public UserManager<IdentityUser> UserManager { get; }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
       }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("IsLoggedIn", "Account");
                    }
                }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult IsLoggedIn()
        {
            if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (signInManager.IsSignedIn(User) && User.IsInRole("Arbetssökande"))
            {
                return RedirectToAction("Index", "Worker");
            }
            else if (signInManager.IsSignedIn(User) && User.IsInRole("Företag"))
            {
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["roles"] = roleManager.Roles.Where(x => x.Name == "Företag" || x.Name == "Arbetssökande").ToList();
            return View();

            //.Where(x => x.Name == "Företag" || x.Name == "Arbetssökande")

        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} finns redan");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewData["roles"] = roleManager.Roles.Where(x => x.Name == "Företag" || x.Name == "Arbetssökande").ToList();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { 
                    UserName = model.Email, 
                    Email = model.Email,
                    Role = model.Role
                };

                var result = await userManager.CreateAsync(user, model.Password);
              

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, user.Role);

                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (signInManager.IsSignedIn(User) && User.IsInRole("Arbetssökande"))
                    {
                        return RedirectToAction("Index", "Worker");
                    }
                    else if (user.Role == "Företag")
                    {
                        var test = new Company
                        {
                            Id = user.Id,
                            Email = user.Email,
                        };

                        _db.Company.Add(test);

                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Company");
                    }
                    else
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "home");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
