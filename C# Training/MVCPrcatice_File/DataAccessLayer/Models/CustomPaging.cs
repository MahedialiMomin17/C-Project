using MVCPrcatice.Models;

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

        public int CurrentPage { get; set; }
    }
}
