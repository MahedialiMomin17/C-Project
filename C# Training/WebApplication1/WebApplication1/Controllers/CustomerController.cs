using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccess;
using WebApplication1.Common;
using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private List<Customer> _customers = new List<Customer>();


        [HttpGet("get-all")]
        public ActionResult GetAll()
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var objCustomer = System.IO.File.ReadAllText(@"D:\\C# Mahediali_GIT\\C# Training\\WebApplication1\\DataAccess\\Data\\Customer.json");

                //var customers
                var customers = JsonConvert.DeserializeObject<List<Customer>>(objCustomer);
              
                objResponse.data = customers;
                objResponse.Message = "Record found successfully.";
                objResponse.Status = 1;

            }
            catch (System.Exception ex)
            {

            }
            return Ok(objResponse);
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult Get(string phoneNumber = "")
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var objCustomer = System.IO.File.ReadAllText(@"D:\\C# Mahediali_GIT\\C# Training\\WebApplication1\\DataAccess\\Data\\Customer.json");

                //var customers
                var customers = JsonConvert.DeserializeObject<List<Customer>>(objCustomer);
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    customers = customers.Where(c => c.PhoneNumber.ToLower().Contains(phoneNumber.ToLower())).ToList();
                }

                //string filterByName = "Karly Mcintosh";
                //var filteredCustomers = customers.Where(c => c.Name == filterByName).ToList();

                objResponse.data = customers;
                objResponse.Message = "Record found successfully.";
                objResponse.Status = 1;

            }
            catch (System.Exception ex)
            {

            }
            return Ok(objResponse);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var objResponse = new CommonJsonResponse();
            try
            {

            }
            catch (System.Exception ex)
            {

            }
            return Ok(objResponse);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                if (customer == null)
                {
                    return BadRequest("Invalid customer data");
                }
                _customers.Add(customer);

                objResponse.Message = "Customer created successfully.";
                objResponse.Status = 1;
                objResponse.data = customer;

                var json1 = System.IO.File.ReadAllText(@"D:\\C# Mahediali_GIT\\C# Training\\WebApplication1\\DataAccess\\Data\\Customer.json");

                var customers = JsonConvert.DeserializeObject<List<Customer>>(json1);

                customers.Add(customer);

                var update = JsonConvert.SerializeObject(customers, Formatting.Indented);

                System.IO.File.WriteAllText(@"D:\\C# Mahediali_GIT\\C# Training\\WebApplication1\\DataAccess\\Data\\Customer.json", update);


                return Ok(objResponse);
            }
            catch (System.Exception ex)
            {

            }
            return Ok(objResponse);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{name}")]
        public ActionResult Put(string name, [FromBody] Customer customer)
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var jsonFilePath = @"D:\\C# Mahediali_GIT\\C# Training\\WebApplication1\\DataAccess\\Data\\Customer.json"; 

                string json = System.IO.File.ReadAllText(jsonFilePath);

                var customers = JsonConvert.DeserializeObject<List<Customer>>(json);

                var customerToUpdate = customers.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());

                if (customerToUpdate != null)
                {
                    customerToUpdate.Name = customer.Name;
                    customerToUpdate.Email = customer.Email;
                    customerToUpdate.PhoneNumber = customer.PhoneNumber;

                    string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

                    System.IO.File.WriteAllText(jsonFilePath, updatedJson);

                    objResponse.Message = "Customer updated successfully.";
                    objResponse.Status = 1;
                }
                else
                {
                    objResponse.Message = "Customer not found.";
                    objResponse.Status = 0;
                }
            }
            catch (System.Exception ex)
            {
                objResponse.Message = ex.Message;
                objResponse.Status = 0;
            }
            return Ok(objResponse);
        }


        // DELETE api/<CustomerController>/5
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var jsonFilePath = @"D:\\C# Mahediali_GIT\\C# Training\\WebApplication1\\DataAccess\\Data\\Customer.json"; 

                string json = System.IO.File.ReadAllText(jsonFilePath);

                var customers = JsonConvert.DeserializeObject<List<Customer>>(json);

                var customerToDelete = customers.FirstOrDefault(c => c.Name.ToLower() == name.ToLower()); 

                if (customerToDelete != null)
                {
                    customers.Remove(customerToDelete);

                   
                    string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            
                    System.IO.File.WriteAllText(jsonFilePath, updatedJson);

                    objResponse.Message = "Customer deleted successfully.";
                    objResponse.Status = 1;
                }
                else
                {
                    objResponse.Message = "Customer not found.";
                    objResponse.Status = 0;
                }
            }
            catch (System.Exception ex)
            {
                objResponse.Message = ex.Message;
                objResponse.Status = 0;
            }
            return Ok(objResponse);
        }

    }
}
