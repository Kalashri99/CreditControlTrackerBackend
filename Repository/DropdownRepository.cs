using CreditContolTrackerAPIs.Dto;
using CreditContolTrackerAPIs.Interface;
using CreditContolTrackerAPIs.Models;
using CreditControlTrackerAPIs.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditContolTrackerAPIs.Repository
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly ApplicationDbContext _context;
        public DropdownRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EntityDto>> GetEntity()
        {
            //return _context.Entities.ToList();
            var entities = await _context.Entities
        .Select(e => new EntityDto
        {
            EntityId = e.EntityId,
            EntityName = e.EntityName
            // Map other properties accordingly
        })
        .ToListAsync();

            return entities;
        }

        public async Task<List<CustomerDto>> GetCustomer()
        {
            var customers =await _context.Customers
        .Select(e => new CustomerDto
        {
            CustomerId = e.CustomerId,
            CustomerName = e.CustomerName,
            CustomerAccountNumber = e.CustomerAccountNumber
            // Map other properties accordingly
        })
        .ToListAsync();

            return customers;
        }


        //public ICollection<CompanyCategoryDto> GetCompanyCategory()
        //{
        //    //return _context.CompanyCategories.ToList();
        //    var companyCategory = _context.CompanyCategories
        //    .Select(e => new CompanyCategoryDto
        //    {
        //        CompanyCategoryId = e.CompanyCategoryId,
        //        CompanyCategoryName = e.CompanyCategoryName,

        //        // Map other properties accordingly
        //    }).ToList();

        //    return companyCategory;
        //}
        public async Task<List<CompanyCategoryDto>> GetCompanyCategory()
        {
            var companyCategories = await _context.CompanyCategories
                .Select(e => new CompanyCategoryDto
                {
                    CompanyCategoryId = e.CompanyCategoryId,
                    CompanyCategoryName = e.CompanyCategoryName,

                // Map other properties accordingly
            }).ToListAsync();

            return companyCategories;
        }


        public async Task<List<InvoiceTypeDto>> GetInvoiceType()
        {
            //return _context.InvoiceTypes.ToList();
            var companyCategory = await _context.InvoiceTypes
            .Select(e => new InvoiceTypeDto
            {
                InvoiceTypeId = e.InvoiceTypeId,
                InvoiceTypeName = e.InvoiceTypeName,

                // Map other properties accordingly
            }).ToListAsync();

            return companyCategory;
        }

        

        public async Task<IEnumerable<InvoiceDetailsDto> >GetInvoiceDetails(string entity, string companyCategory, string invoiceType, string customer)
        {
            var query = _context.InvoiceDetails.AsQueryable();

            if (!string.IsNullOrEmpty(entity))
            {
                query = query.Where(i => i.Entity.EntityName == entity);
            }

            if (!string.IsNullOrEmpty(companyCategory))
            {
                query = query.Where(i => i.CompanyCategory.CompanyCategoryName == companyCategory);
            }

            if (!string.IsNullOrEmpty(invoiceType))
            {
                query = query.Where(i => i.InvoiceType.InvoiceTypeName == invoiceType);
            }

            if (!string.IsNullOrEmpty(customer))
            {
                query = query.Where(i => i.customer.CustomerName == customer);
            }

            var invoiceDetails = await MapToInvoiceDetailsDto(query);
            

            return invoiceDetails;
        }



        public async Task<ICollection<InvoiceDetailsDto>> GetAllInvoiceDetails()
        {
            var query = _context.InvoiceDetails.AsQueryable();
            var invoiceDetails = await MapToInvoiceDetailsDto(query);

            return invoiceDetails;
        }


        private async Task<List<InvoiceDetailsDto> >MapToInvoiceDetailsDto(IQueryable<InvoiceDetail> query)
        {
            var invoiceDetails = await query.Select(d => new InvoiceDetailsDto
            {
                InvoiceNo = d.InvoiceNo,
                Entity = d.Entity.EntityName,
                PoNo = d.PoNo,
                InvoiceDate = d.InvoiceDate,
                DueDate = d.DueDate,
                BalanceInCurrency = d.BalanceInCurrency,
                Currency = d.Currency,
                Usdbalance = d.Usdbalance,
                Provisioning = d.Provisioning,
                BalanceInUsd = d.BalanceInUsd,
                CreditNoteDiscounts = d.CreditNoteDiscounts,
                CreditUsdamount = d.CreditUsdamount,
                AccountManager = d.AccountManager,
                Cell = d.Cell,
                BrnFacTuName = d.BrnFacTuName,
                NewBu = d.NewBu,
                ArPoc = d.ArPoc,
                NewDu = d.NewDu,
                NewOu = d.NewOu,
                InvoiceTypeId=d.InvoiceTypeId,
                ContractPartyName = d.ContractPartyName,
                ProjectContractId = d.ProjectContractId,
                InvoiceManager = d.InvoiceManager,
                SalesPocasperIms = d.SalesPocasperIms,
                OtherReference = d.OtherReference,
                DeliveryPartner = d.DeliveryPartner,
                DeliveryHead = d.DeliveryHead,
                SalesPoc = d.SalesPoc,
                SalesVp = d.SalesVp,
                FusionAccountNumber = d.FusionAccountNumber,
                FusionAccountName = d.FusionAccountName,
                UpdatedSalesPoc = d.UpdatedSalesPoc,
                UpdatedSalesVp = d.UpdatedSalesVp,
                AccountType = d.AccountType.AccountTypeName,
                CustomerName = d.customer.CustomerName,
                CustomerAccountNumber = d.customer.CustomerAccountNumber,
                Aging = d.Aging.AgingName,
                CompanyCategory = d.CompanyCategory.CompanyCategoryName,
                InvoiceStatus = d.InvoiceStatus.InvoiceName,
                InvoiceType = d.InvoiceType.InvoiceTypeName,
                Category = d.Category,
                PaymentTerm= d.PaymentTerm


            }).ToListAsync();
            var invoiceNos = invoiceDetails.Select(d => d.InvoiceNo).ToList();
            var receipts = _context.Receipts.Where(r => invoiceNos.Contains(r.InvoiceNo)).ToList();

            foreach (var invoiceDetail in invoiceDetails)
            {
                // Find the associated Receipt for each InvoiceDetailsDto
                var receipt = receipts.FirstOrDefault(r => r.InvoiceNo == invoiceDetail.InvoiceNo);

                // Map the relevant Receipt properties to InvoiceDetailsDto
                if (receipt != null)
                {
                    //invoiceDetail.ReceiptId = receipt.ReceiptId;
                    invoiceDetail.Date = receipt.Date;
                    invoiceDetail.RecOrigCurrAmount = receipt.RecOrigCurrAmount;
                    invoiceDetail.AmountInUsd = receipt.AmountInUsd;
                    invoiceDetail.ReceivedIn = receipt.ReceivedIn;
                    invoiceDetail.CheckWire = receipt.CheckWire;
                    invoiceDetail.BankName = receipt.BankName;
                    invoiceDetail.Column8 = receipt.Column8;
                    // ... map other properties
                }

                //return invoiceDetails;
            }
            return invoiceDetails;

        }

  //      var entities = _context.Entities
  //.Select(e => new EntityDto
  //{
  //    EntityId = e.EntityId,
  //    EntityName = e.EntityName
  //    // Map other properties accordingly
  //})
  //.ToList(); 

        public IEnumerable<String> GetColumns()
        {
            var col = _context.Model.FindEntityType(typeof(InvoiceDetail));
            var columnNames = col.GetProperties()
                .Select(p=>p.GetColumnName())
                .ToList();
            //var col = $"SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('InvoiceDetails')";
            //var query = _context.InvoiceDetails.AsQueryable();
            //var col = _context.InvoiceDetails.
            //    Select(e => e.name
            //    )
            //SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('InvoiceDetails')
            return columnNames;
        }

        public async Task<IEnumerable<AnalyticReport>> GetCustomerInvoice(int Id)
        {
            //var query = _context.Database.SqlQueryRaw<Customer>("EXEC GetCustomerDataById @CustomerId", new SqlParameter("@CustomerId", Id));



            //// Execute the query and retrieve the customer
            //var customer = query.SingleOrDefault();



            //return (IEnumerable<Customer>)customer;
            //var parameters = new SqlParameter("@CustomerId", Id);



            // Call the stored procedure using Entity Framework's FromSqlRaw method
            var customers = _context.AnalyticReports.FromSql($"GetInvoiceDetailsByCustomer {Id}").ToList();



            //var customer = customers.FirstOrDefault();



            return (IEnumerable<AnalyticReport>)customers;
        }
    }
}

