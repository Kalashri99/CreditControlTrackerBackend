using CreditControlTrackerAPIs.Models;
using System;
using System.Collections.Generic;

namespace CreditContolTrackerAPIs.Models;

public partial class Receipt
{
    public int ReceiptId { get; set; }

    public DateTime? Date { get; set; }

    public long? RecOrigCurrAmount { get; set; }

    public long? AmountInUsd { get; set; }

    public string ReceivedIn { get; set; }

    public string CheckWire { get; set; }

    public string BankName { get; set; }

    public long Column8 { get; set; }

    public string InvoiceNo { get; set; }

    public virtual InvoiceDetail InvoiceNoNavigation { get; set; }
}
