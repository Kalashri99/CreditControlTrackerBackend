using System;
using System.Collections.Generic;

namespace CreditControlTrackerAPIs.Models;

public partial class AccountType
{
    public int AccountTypeId { get; set; }

    public string AccountTypeName { get; set; }

    public virtual ICollection<InvoiceDetail> invoiceDetail { get; set; }
}
