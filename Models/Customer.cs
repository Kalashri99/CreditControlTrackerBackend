using CreditControlTrackerAPIs.Models;
using System;
using System.Collections.Generic;

namespace CreditContolTrackerAPIs.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string CustomerAccountNumber { get; set; }

    public string CompanyCategory { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
