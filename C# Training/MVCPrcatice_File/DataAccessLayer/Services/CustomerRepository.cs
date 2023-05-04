using CommonLibrary;
using DataAccessLayer.Interface;
using MVCPractice.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPrcatice.Models;
using Stripe;
using Customer = MVCPrcatice.Models.Customer;

namespace MVCPractice.Services
{
    public class CustomerRepository : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;

        public CustomerRepository()
        {
            var client = new MongoClient(AppConfiguration.connectionString);
            var database = client.GetDatabase(AppConfiguration.databaseName);
            _customerCollection = database.GetCollection<Customer>("Users");
        }




        public List<Customer> GetEmailCustomer(string email)
        {
            var users = _customerCollection.Find(x => x.Email == email).ToList();
            return users;
        }


        public CustomerPaging SearchCustomer(string searchText, string sortby = "Name", string orderby = "asc", int page = 1, int pageSize = 15)
        {

            var filter = Builders<Customer>.Filter.Empty;

            if (!string.IsNullOrEmpty(searchText))
            {
                filter &= Builders<Customer>.Filter.Regex(field: "Email", regex: new BsonRegularExpression(pattern: searchText, options: "i")) |
                          Builders<Customer>.Filter.Regex(field: "Name", regex: new BsonRegularExpression(pattern: searchText, options: "i")) |
                          Builders<Customer>.Filter.Regex(field: "Phone", regex: new BsonRegularExpression(pattern: searchText, options: "i"));
            }

            var sort = orderby == "asc" ? Builders<Customer>.Sort.Ascending(sortby) : Builders<Customer>.Sort.Descending(sortby);
            var objCustomers = _customerCollection.Find(filter).Sort(sort);//.Skip((page - 1) * pageSize).Limit(pageSize).ToList();


            var ObjResponse = new CustomerPaging()
            {
                Page = page,
                PageSize = pageSize,
                TotalPage = System.Convert.ToInt32(System.Math.Ceiling(objCustomers.Count() / System.Convert.ToDouble(pageSize))),
                TotalRecord = objCustomers.Count(),
                Records = objCustomers.Skip((page - 1) * pageSize).Limit(pageSize).ToList()
            };

            return ObjResponse;
        }
    }
}
