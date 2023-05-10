using CreditContolTrackerAPIs.Interface;
using CreditContolTrackerAPIs.Models;
using CreditControlTrackerAPIs.Models;

namespace CreditContolTrackerAPIs.Repository
{
        public class DropdownRepository : IDropdownRepository
        {
            private readonly ApplicationDbContext _context;
            public DropdownRepository(ApplicationDbContext context)
            {
                _context = context;
            }

        public ICollection<Entity> GetEntity()
        {
            return _context.Entities.ToList();
        }

        public ICollection<Customer> GetCustomer()
        {
            return _context.Customers.ToList();
        }

        public ICollection<CompanyCategory> GetCompanyCategory()
        {
            return _context.CompanyCategories.ToList();
        }

        public ICollection<InvoiceType> GetInvoiceType()
        {
            return _context.InvoiceTypes.ToList();
        }
    }
    }
