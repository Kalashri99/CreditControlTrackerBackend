using CreditControlTrackerAPIs.Models;

namespace CreditContolTrackerAPIs.Models
{
    public class pagenationResponse
    {
       public int TotalCount { get; set; }
        public int PageCount { get; set; }  
        public ICollection<InvoiceDetail> items { get; set; }
    }
}
