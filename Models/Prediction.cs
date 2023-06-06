using System.ComponentModel.DataAnnotations;
namespace CreditContolTrackerAPIs.Models
{
    public class Prediction
    {
        [Key]
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public long? BalanceInUsd { get; set; }

        public DateTime? Predicted_Date { get; set; }

    }
}
