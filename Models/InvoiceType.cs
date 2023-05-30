using System;
using System.Collections.Generic;

namespace CreditControlTrackerAPIs.Models;

public partial class InvoiceType
{
    public int InvoiceTypeId { get; set; }

    public string InvoiceTypeName { get; set; }
    public virtual ICollection<InvoiceDetail> invoiceDetail { get; set; }
}
