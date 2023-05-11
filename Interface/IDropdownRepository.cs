using CreditControlTrackerAPIs.Models;

namespace CreditContolTrackerAPIs.Interface
{
    public interface IDropdownRepository
    {
        ICollection<Entity> GetEntity();
        ICollection<Customer> GetCustomer();
        ICollection<CompanyCategory> GetCompanyCategory();
        ICollection<InvoiceType> GetInvoiceType();
        ICollection<InvoiceDetail> GetInvoiceDetails();
    }
}
