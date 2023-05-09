using System;
using System.Collections.Generic;

namespace CreditControlTrackerAPIs.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerAccountNumber { get; set; }
    public virtual ICollection<InvoiceDetail> invoiceDetail { get; set; }
}
