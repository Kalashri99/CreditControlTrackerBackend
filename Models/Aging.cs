using CreditControlTrackerAPIs.Models;
using System;
using System.Collections.Generic;

namespace CreditContolTrackerAPIs.Models;

public partial class Aging
{
    public int AgingId { get; set; }

    public string AgingName { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
