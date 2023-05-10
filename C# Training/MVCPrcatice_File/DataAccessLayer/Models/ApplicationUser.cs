using Microsoft.AspNetCore.Mvc;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using MongoDB.Bson;

namespace MVCPrcatice.Models
{

    [CollectionName("ApplicationUsers")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

    }
}
