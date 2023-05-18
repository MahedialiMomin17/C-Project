using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using MVCPractice.Models;
using MVCPractice.Services;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;

namespace MVCPrcatice.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMemoryCache _memoryCache;

        public CustomerModel(CustomerRepository customerRepository, IMemoryCache memoryCache)
        {
            _customerRepository = customerRepository;
            _memoryCache = memoryCache;
        }
        public CustomerPaging Customers { get; set; }
        public string SearchTerm { get; set; }
        public string SortBy { get; set; }
        public string OrderBy { get; set; }
        public int PageIndex { get; set; }

        
        public IActionResult OnGet(string search="", int pageNo=1,  string sortby = "name", string orderby = "asc")
        {

            Customers =  _customerRepository.SearchCustomer(search, sortby, orderby, pageNo, pageSize: 3);
            SearchTerm = search;
            SortBy = sortby;
            orderby = (orderby == "asc" ? "desc" : "asc");
            OrderBy = orderby;
            return Page();
        }
    }
}
