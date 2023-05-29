using CreditControlTrackerAPIs.Models;
using System;
using System.Collections.Generic;

namespace CreditContolTrackerAPIs.Models;

public partial class Entity
{
    public int EntityId { get; set; }

    public string EntityName { get; set; }

    public virtual ICollection<InvoiceDetail> invoiceDetail { get; set; }
}
