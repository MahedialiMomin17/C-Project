using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace MVCPrcatice.Models
{

    [CollectionName("Role")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    {

        public string Description { get; set; }
    }
}
