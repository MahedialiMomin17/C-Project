
using MVCPractice.Models;
using MVCPrcatice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ICustomerService
    {
        CustomerPaging SearchCustomer(string searchText, string sortby = "Name", string orderby = "asc", int page = 1, int pageSize = 15);

        List<Customer> GetEmailCustomer(string email);
    }
}
