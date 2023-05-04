using MVCPrcatice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPractice.Models
{
    public class CustomerPaging : CustomPaging
    {
        public List<Customer> Records { get; set; }
    }
    public class CustomPaging
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public long TotalRecord { get; set; }

    }
}
