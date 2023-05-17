using MVCPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCPrcatice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Models;
using MVCPrcatice.Common;

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



        //public IActionResult AccessDenied(string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    return View();
        //}




        public ActionResult Register()
        {
            //var TotalRoles = _roleManager.Roles.Count();
            //if (TotalRoles == 0)
            //{
            //    var objrole = _roleManager.CreateAsync(new ApplicationRole() { Name = "Admin", Description = "Admin role" }).Result;
            //    objrole = _roleManager.CreateAsync(new ApplicationRole() { Name = "Employee", Description = "Employee role" }).Result;
            //    objrole = _roleManager.CreateAsync(new ApplicationRole() { Name = "Editor", Description = "Editor role" }).Result;

            //}
            var model = new RegisterViewModel();
            // ViewBag.Roles = _roleManager.Roles.Select(p => new SelectListItem { Text = p.Name, Value = p.Name }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationuser = new ApplicationUser() { FirstName = model.FirstName, LastName = model.LastName, Address = model.Address, PhoneNumber = model.PhoneNumber, Email = model.Email, UserName = model.Email };
                var objUser = _userManager.CreateAsync(applicationuser, model.Password).Result;
                if (objUser.Succeeded)
                {
                    string role = "Employee";
                    _userManager.AddToRoleAsync(applicationuser, role);
                    ViewBag.Message = "User Created Successfully";
                }
                else
                {
                    foreach (IdentityError error in objUser.Errors)
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
           // ViewBag.Roles = _roleManager.Roles.Select(p => new SelectListItem { Text = p.Name, Value = p.Name }).ToList();
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
                        return RedirectToAction("Index", "Customer");
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

            return RedirectToAction("Roles");
        }




        [Authorize(Roles = "Admin")]
        public ActionResult User()
        {
            var users = _userManager.Users.ToList();
            ViewBag.Roles = _roleManager.Roles.ToList().Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToList();
            return View(users);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateRole(string id, string role)
        {
            var objResponse = new CommonJsonResponse();

            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                objResponse.Message = "User not found";
                objResponse.Status = 0;
                return Json(objResponse);
            }

            if (user.Roles != null && user.Roles.Count > 0)
            {
                user.Roles.Clear();
                _userManager.UpdateAsync(user);
            }
            //var rolesToRemove = _userManager.GetRolesAsync(user).Result;

            //var result = _userManager.RemoveFromRolesAsync(user, rolesToRemove).Result;

            var result = _userManager.AddToRoleAsync(user, role).Result;
            if (result.Succeeded)
            {
                objResponse.Message = "Role updated successfully";
                objResponse.Status = 1;
                objResponse.data = role; 
                return Json(objResponse);
            }
            else
            {
                objResponse.Message = "Failed to update role";
                objResponse.Status = 0;
                return Json(objResponse);
            }

        }




        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var model = new RoleViewModel
            {
                Name = role.Name,
                Description = role.Description,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var role = await _roleManager.FindByNameAsync(model.Name);
            if (role == null)
            {
                return NotFound();
            }
            role.Description = model.Description;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Roles", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);

        }




        //[HttpGet]
        //public async Task<IActionResult> deleteRole(string id)
        //{
        //    var role = await _roleManager.FindByIdAsync(id);
        //    if (role == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new RoleViewModel
        //    {
        //        Name = role.Name
        //    };

        //    return View(model);
        //}



        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return NotFound();
                }

                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    objResponse.Message = "Role deleted successfully";
                    objResponse.Status = 1;      
                    return Json(objResponse);
                }
                else
                {
                    objResponse.Message = "Failed to delete role";
                    objResponse.Status = 0;
                    return Json(objResponse);
                }
            }
            catch (Exception ex)
            {
                objResponse.Message = $"Error: {ex.Message}";
                objResponse.Status = 0;
                return Json(objResponse);
            }
        }

    }
}
