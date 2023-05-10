using System;
using System.Collections.Generic;

namespace CreditControlTrackerAPIs.Models;

public partial class Aging
{
    public int AgingId { get; set; }

    public string? AgingName { get; set; } = null!;
    public virtual ICollection<InvoiceDetail> invoiceDetail { get; set; }
}
