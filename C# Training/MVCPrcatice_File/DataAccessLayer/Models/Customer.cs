using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MVCPrcatice.Models
{
    public class Customer
    {

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }



        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name should only contain alphabets")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone should be a 10-digit number")]
        public string Phone { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        [Remote("IsEmailExist", "Customer", ErrorMessage = "Email Already Exist. Please choose another email.")]

        public string Email { get; set; }



        [Required(ErrorMessage = "City is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "City must only contain alphabetic characters")]
        public string City { get; set; }

        public string FileName { get; set; }
        public string ImageUrl { get; set; }

        internal static object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
