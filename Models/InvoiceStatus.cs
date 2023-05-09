using System;
using System.Collections.Generic;

namespace CreditControlTrackerAPIs.Models;

public partial class InvoiceStatus
{
    public int InvoiceStatusId { get; set; }

    public string InvoiceName { get; set; }
    public virtual ICollection<InvoiceDetail> invoiceDetail { get; set; }
}
