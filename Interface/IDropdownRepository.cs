using CreditContolTrackerAPIs.Dto;
using CreditControlTrackerAPIs.Models;

namespace CreditContolTrackerAPIs.Interface
{
    public interface IDropdownRepository
    {
        ICollection<EntityDto> GetEntity();
        ICollection<CustomerDto> GetCustomer();
        ICollection<CompanyCategoryDto> GetCompanyCategory();
        ICollection<InvoiceTypeDto> GetInvoiceType();
        IEnumerable<InvoiceDetailsDto> GetInvoiceDetails(string Entity, string CompanyCategory, string InvoiceType, string Customer);
        ICollection<InvoiceDetailsDto> GetAllInvoiceDetails();
        ICollection<InvoiceDetailsDto> GetAllInvoiceDetailByCustomerId(int id);
    }
}
