using System;
using System.Collections.Generic;

namespace CreditControlTrackerAPIs.Models;

public partial class Entity
{
    public int EntityId { get; set; }

    public string EntityName { get; set; }
    public virtual ICollection<InvoiceDetail> invoiceDetail { get; set; }
}
