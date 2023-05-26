using CreditContolTrackerAPIs.Dto;
using CreditControlTrackerAPIs.Models;

namespace CreditContolTrackerAPIs.Interface
{
    public interface IDropdownRepository
    {
        Task<List<EntityDto>> GetEntity();
        Task<List<CustomerDto>> GetCustomer();
        //ICollection<CompanyCategoryDto>GetCompanyCategory();
        Task<List<CompanyCategoryDto>> GetCompanyCategory();
        //Task<List<CompanyCategoryDto>>
        Task<List<InvoiceTypeDto>> GetInvoiceType();
        Task<IEnumerable<InvoiceDetailsDto>> GetInvoiceDetails(string Entity, string CompanyCategory, string InvoiceType, string Customer);
        Task<ICollection<InvoiceDetailsDto>> GetAllInvoiceDetails();
        ICollection<InvoiceDetailsDto> GetAllInvoiceDetailByCustomerId(int id);
        IEnumerable<String> GetColumns();
    }
}
