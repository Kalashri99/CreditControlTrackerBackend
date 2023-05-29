using CreditContolTrackerAPIs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditControlTrackerAPIs.Models;

public partial class AnalyticReport
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

