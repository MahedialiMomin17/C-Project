using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [DisplayName("Role")]
        public string RoleId { get; set; }

        //public List<SelectListItem> Roles { get; set; } 

    }

    public class loginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
