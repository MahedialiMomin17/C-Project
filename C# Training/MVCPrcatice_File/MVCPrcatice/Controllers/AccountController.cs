using MVCPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCPrcatice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Models;

namespace MVCPrcatice.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {   
        public UserManager<ApplicationUser> _userManager { get; set; }
        public RoleManager<ApplicationRole> _roleManager { get; set; }
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
            _roleManager = roleManager;

        }


        public ActionResult Register()
        {
            //var TotalRoles = _roleManager.Roles.Count();
            //if (TotalRoles == 0)
            //{
            //    var objrole = _roleManager.CreateAsync(new ApplicationRole() { Name = "Admin", Description = "Admin role" }).Result;
            //    objrole = _roleManager.CreateAsync(new ApplicationRole() { Name = "Employee", Description = "Employee role" }).Result;
            //}
            //var model = new RegisterViewModel();
            ViewBag.Roles = _roleManager.Roles.Select(p => new SelectListItem { Text = p.Name, Value = p.Name }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationuser = new ApplicationUser() { FirstName = model.FirstName, LastName = model.LastName, Address = model.Address, PhoneNumber = model.PhoneNumber, Email=model.Email, UserName=model.Email };
                var objUser = _userManager.CreateAsync(applicationuser, model.Password).Result;
                if (objUser.Succeeded)
                {
                    _userManager.AddToRoleAsync(applicationuser, model.RoleId);
                    ViewBag.Message = "User Created Successfully";
                }
                else
                {
                    foreach(IdentityError error in objUser.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ViewBag.error = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

            }
            ViewBag.Roles = _roleManager.Roles.Select(p => new SelectListItem { Text = p.Name, Value = p.Name }).ToList();
            return View(model);
        }
        

        public ActionResult Login()
        {
            return View(new loginViewModel());
        }

        [HttpPost]

        public ActionResult Login(loginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = _userManager.FindByEmailAsync(model.Email).Result;
                if (appUser != null)
                {
                    var result = signInManager.PasswordSignInAsync(appUser, model.Password, false, true).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(model.Email), "Login Failed: Invalid Email or Password");
            }
            else
            {
                ViewBag.error = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

            }

            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        [Authorize(Roles = "Admin")]
        public ActionResult Roles()
        {
            var objRoles = _roleManager.Roles.ToList();
            return View(objRoles);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole(RoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objrole = _roleManager.CreateAsync(new ApplicationRole { Name = model.Name, Description = model.Description }).Result;
                if (objrole.Succeeded)
                    ViewBag.Message = "Role Created Successfully";
                else
                {
                    foreach (IdentityError error in objrole.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                ViewBag.error = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

            }

            return View(model);
        }

    }
}
