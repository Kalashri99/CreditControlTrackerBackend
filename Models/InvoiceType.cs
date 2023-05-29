using CreditControlTrackerAPIs.Models;
using System;
using System.Collections.Generic;

namespace CreditContolTrackerAPIs.Models;

public partial class InvoiceType
{
    public int InvoiceTypeId { get; set; }

    public string InvoiceTypeName { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
