using System.ComponentModel.DataAnnotations;

namespace CreditContolTrackerAPIs.Models
{
    public class TotalAnalysis
    {
[Key] 
       public int pending_invoices { get; set; }   
       public int paid_invoices { get; set; }   
       public int late_Paid_invoices { get; set; }   
       public decimal pending_revenue { get; set; }
       public decimal total_Revenue { get; set; }
       public int total_invoices { get; set; }
       public decimal  percentageOfPendingInvoices{ get; set; }
       public decimal  percentageOfRevenueOnHold{ get; set; }

    }
}
