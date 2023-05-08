
using MVCPractice.Models;
using MVCPrcatice.Models;

namespace DataAccessLayer.Interface
{
    public interface ICustomerService
    {

        IEnumerable<Customer> GetAllCustomers();

        void DeleteCustomer(string id);

        CustomerPaging SearchCustomer(string searchText, string sortby = "Name", string orderby = "asc", int page = 1, int pageSize = 15);

        List<Customer> GetEmailCustomer(string email);
    }
}
