using System.ComponentModel.DataAnnotations;

namespace CreditContolTrackerAPIs.Models
{
    public class AnalyticReport
    {
        [Key]
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CreditChange { get; set; }
        public int CustomerId { get; set; }
        public long Usdbalance { get; set; }
        public string CompanyCategoryName { get; set; }
    }
}
