using CommonLibrary;
using DataAccessLayer.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using MVCPractice.Models;
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


        //public List<Customer> GetAllCustomers()
        //{
        //    var customers = _customerCollection.Find(Builders<Customer>.Filter.Empty).ToList();
        //    return customers;
        //}

        public List<Customer> GetAllCustomers()
        {
            return _customerCollection.Find(x => true).ToList();
        }


        //public IEnumerable<Customer> GetAllCustomers()
        //{
        //    var customers = _customerCollection.Find(Builders<Customer>.Filter.Empty).ToList();
        //    return customers.Select(c =>
        //    {
        //        c.Id = c.Id.ToString(); // Convert ObjectId to string
        //        return c;
        //    });
        //}


        public CustomerRepository(IMongoDatabase database)
        {
            _customerCollection = database.GetCollection<Customer>("Customers");
        }

        public void InsertCustomer(Customer customer)
        {
            _customerCollection.InsertOne(customer);
        }


        public Customer GetCustomerById(string id)
        {
            return _customerCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        //public Customer GetCustomerById(string id)
        //{
        //    var objectId = ObjectId.Parse(id);
        //    return _customerCollection.Find(x => x.Id == objectId).FirstOrDefault();
        //}

        public void UpdateCustomer(Customer customer)
        {
            _customerCollection.ReplaceOne(x => x.Id == customer.Id, customer);
        }

        public void DeleteCustomer(string id)
        {
            GetMongoCollection().DeleteOne(x => x.Id == id);
        }

        //public void DeleteCustomer(string id)
        //{
        //    var objectId = ObjectId.Parse(id);
        //    GetMongoCollection().DeleteOne(x => x.Id == objectId);
        //}

        private IMongoCollection<Customer> GetMongoCollection()
        {
            return _customerCollection;
        }


        public List<Customer> GetEmailCustomer(string email)
        {
            var users = _customerCollection.Find(x => x.Email == email).ToList();
            return users;
        }


        public CustomerPaging SearchCustomer(string searchText, string sortby = "Name", string orderby = "asc", int page = 1, int pageSize = 3)
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
