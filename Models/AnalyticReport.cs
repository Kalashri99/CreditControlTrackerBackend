using CreditControlTrackerAPIs.Models;
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
        public long BalanceInUsd { get; set; }
        public string CompanyCategoryName { get; set; }
        public string InvoiceName { get; set; }
        public string CustomerName { get; set; }
    }
}
