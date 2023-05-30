using System;
using System.Collections.Generic;

namespace CreditControlTrackerAPIs.Models;

public partial class CompanyCategory
{
    public int CompanyCategoryId { get; set; }

    public string CompanyCategoryName { get; set; }
    public virtual ICollection<InvoiceDetail> invoiceDetail { get; set; }
}
