using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using RemoteAttribute = Microsoft.AspNetCore.Mvc.RemoteAttribute;

namespace MVCPrcatice.Models
{
    public class Customer
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 50 characters")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone should be a 10-digit number")]
        public string Phone { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        [Remote("IsEmailExist", "Home", ErrorMessage = "Email Already Exist. Please choose another email.")]
        public string Email { get; set; }




        [Required(ErrorMessage = "City is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "City must only contain alphabetic characters")]
        public string City { get; set; }

        //public string FileName { get; set; }

    }
}
