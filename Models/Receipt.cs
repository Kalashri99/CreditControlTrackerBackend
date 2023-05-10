using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditControlTrackerAPIs.Models;

public partial class Receipt
{
    public int ReceiptId { get; set; }   

    public DateTime? Date { get; set; }  

    public long? RecOrigCurrAmount { get; set; } 

    public long? AmountInUsd { get; set; }

    public string? ReceivedIn { get; set; }

    public string? CheckWire { get; set; }

    public string? BankName { get; set; }

    public long Column8 { get; set; }
    public string InvoiceNo { get; set; }
    [ForeignKey("InvoiceNo")]
    public InvoiceDetail InvoiceDetail { get; set; }
}
