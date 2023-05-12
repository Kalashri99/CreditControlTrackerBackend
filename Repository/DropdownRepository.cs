using CreditContolTrackerAPIs.Dto;
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

        public ICollection<EntityDto> GetEntity()
        {
            //return _context.Entities.ToList();
            var entities = _context.Entities
        .Select(e => new EntityDto
        {
            EntityId = e.EntityId,
            EntityName = e.EntityName
            // Map other properties accordingly
        })
        .ToList();

            return entities;
        }

        public ICollection<CustomerDto> GetCustomer()
        {
            var customers = _context.Customers
        .Select(e => new CustomerDto
        {
            CustomerId = e.CustomerId,
            CustomerName = e.CustomerName,
            CustomerAccountNumber = e.CustomerAccountNumber
            // Map other properties accordingly
        })
        .ToList();

            return customers;
        }


        public ICollection<CompanyCategoryDto> GetCompanyCategory()
        {
            //return _context.CompanyCategories.ToList();
            var companyCategory = _context.CompanyCategories
            .Select(e => new CompanyCategoryDto
            {
                CompanyCategoryId = e.CompanyCategoryId,
                CompanyCategoryName = e.CompanyCategoryName,

            // Map other properties accordingly
        }).ToList();

            return companyCategory;
        }


        public ICollection<InvoiceTypeDto> GetInvoiceType()
        {
            //return _context.InvoiceTypes.ToList();
            var companyCategory = _context.InvoiceTypes
            .Select(e => new InvoiceTypeDto
            {
                InvoiceTypeId = e.InvoiceTypeId,
                InvoiceTypeName = e.InvoiceTypeName,

                // Map other properties accordingly
            }).ToList();

            return companyCategory;
        }

        //public IEnumerable<InvoiceDetailsDto> GetInvoiceDetails(string Entity, string CompanyCategory, string InvoiceType, string Customer)
        //{
        //    var query = _context.InvoiceDetails.AsQueryable();

        //    if (!string.IsNullOrEmpty(Entity))
        //    {
        //        query = query.Where(i => i.Entity.EntityName == Entity);
        //    }

        //    if (!string.IsNullOrEmpty(CompanyCategory))
        //    {
        //        query = query.Where(i => i.CompanyCategory.CompanyCategoryName == CompanyCategory);
        //    }

        //    if (!string.IsNullOrEmpty(InvoiceType))
        //    {
        //        query = query.Where(i => i.InvoiceType.InvoiceTypeName == InvoiceType);
        //    }

        //    if (!string.IsNullOrEmpty(Customer))
        //    {
        //        query = query.Where(i => i.customer.CustomerName == Customer);
        //    }
        //    var invoiceDetails = query.Select(d => new InvoiceDetailsDto
        //    {

        //        InvoiceNo = d.InvoiceNo,
        //        Entity = d.Entity.EntityName,
        //        PoNo = d.PoNo,
        //        InvoiceDate = d.InvoiceDate,
        //        DueDate = d.DueDate,
        //        BalanceInCurrency = d.BalanceInCurrency,
        //        Currency = d.Currency,
        //        Usdbalance = d.Usdbalance,
        //        Provisioning = d.Provisioning,
        //        BalanceInUsd = d.BalanceInUsd,
        //        CreditNoteDiscounts = d.CreditNoteDiscounts,
        //        CreditUsdamount = d.CreditUsdamount,
        //        AccountManager = d.AccountManager,
        //        Cell = d.Cell,
        //        BrnFacTuName = d.BrnFacTuName,
        //        NewBu = d.NewBu,
        //        ArPoc = d.ArPoc,
        //        NewDu = d.NewDu,
        //        NewOu = d.NewOu,
        //        InvoiceTypeId = d.InvoiceTypeId,
        //        ContractPartyName = d.ContractPartyName,
        //        ProjectContractId = d.ProjectContractId,
        //        InvoiceManager = d.InvoiceManager,
        //        SalesPocasperIms = d.SalesPocasperIms,
        //        OtherReference = d.OtherReference,
        //        DeliveryPartner = d.DeliveryPartner,
        //        DeliveryHead = d.DeliveryHead,
        //        SalesPoc = d.SalesPoc,
        //        SalesVp = d.SalesVp,
        //        FusionAccountNumber = d.FusionAccountNumber,
        //        FusionAccountName = d.FusionAccountName,
        //        UpdatedSalesPoc = d.UpdatedSalesPoc,
        //        UpdatedSalesVp = d.UpdatedSalesVp,
        //        AccountType = d.AccountType.AccountTypeName,
        //        Customer=d.customer.CustomerName,
        //        Aging=d.Aging.AgingName,
        //        CompanyCategory=d.CompanyCategory.CompanyCategoryName,
        //        InvoiceStatus=d.InvoiceStatus.InvoiceName,
        //        InvoiceType=d.InvoiceType.InvoiceTypeName

        //        // Map other properties accordingly
        //    }).ToList();

        //    return invoiceDetails;

        //   // return query.ToList();
        //    //return Ok(query.ToList());
        //}

        //public ICollection<InvoiceDetailsDto> GetAllInvoiceDetails()
        //{
        //    var query = _context.InvoiceDetails.AsQueryable();
        //var invoiceDetails = query.Select(d => new InvoiceDetailsDto
        //{
        //    InvoiceNo = d.InvoiceNo,
        //    Entity = d.Entity.EntityName,
        //    PoNo = d.PoNo,
        //    InvoiceDate = d.InvoiceDate,
        //    DueDate = d.DueDate,
        //    BalanceInCurrency = d.BalanceInCurrency,
        //    Currency = d.Currency,
        //    Usdbalance = d.Usdbalance,
        //    Provisioning = d.Provisioning,
        //    BalanceInUsd = d.BalanceInUsd,
        //    CreditNoteDiscounts = d.CreditNoteDiscounts,
        //    CreditUsdamount = d.CreditUsdamount,
        //    AccountManager = d.AccountManager,
        //    Cell = d.Cell,
        //    BrnFacTuName = d.BrnFacTuName,
        //    NewBu = d.NewBu,
        //    ArPoc = d.ArPoc,
        //    NewDu = d.NewDu,
        //    NewOu = d.NewOu,
        //    InvoiceTypeId = d.InvoiceTypeId,
        //    ContractPartyName = d.ContractPartyName,
        //    ProjectContractId = d.ProjectContractId,
        //    InvoiceManager = d.InvoiceManager,
        //    SalesPocasperIms = d.SalesPocasperIms,
        //    OtherReference = d.OtherReference,
        //    DeliveryPartner = d.DeliveryPartner,
        //    DeliveryHead = d.DeliveryHead,
        //    SalesPoc = d.SalesPoc,
        //    SalesVp = d.SalesVp,
        //    FusionAccountNumber = d.FusionAccountNumber,
        //    FusionAccountName = d.FusionAccountName,
        //    UpdatedSalesPoc = d.UpdatedSalesPoc,
        //    UpdatedSalesVp = d.UpdatedSalesVp,
        //    AccountType = d.AccountType.AccountTypeName,
        //    Customer = d.customer.CustomerName,
        //    Aging = d.Aging.AgingName,
        //    CompanyCategory = d.CompanyCategory.CompanyCategoryName,
        //    InvoiceStatus = d.InvoiceStatus.InvoiceName,
        //    InvoiceType = d.InvoiceType.InvoiceTypeName
        //}).ToList();
        //return invoiceDetails.ToList();


        //}

        public IEnumerable<InvoiceDetailsDto> GetInvoiceDetails(string entity, string companyCategory, string invoiceType, string customer)
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

            var invoiceDetails = MapToInvoiceDetailsDto(query);

            return invoiceDetails;
        }

        public ICollection<InvoiceDetailsDto> GetAllInvoiceDetails()
        {
            var query = _context.InvoiceDetails.AsQueryable();
            var invoiceDetails = MapToInvoiceDetailsDto(query);

            return invoiceDetails;
        }

        private List<InvoiceDetailsDto> MapToInvoiceDetailsDto(IQueryable<InvoiceDetail> query)
        {
            var invoiceDetails = query.Select(d => new InvoiceDetailsDto
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
                InvoiceTypeId = d.InvoiceTypeId,
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
                Customer = d.customer.CustomerName,
                Aging = d.Aging.AgingName,
                CompanyCategory = d.CompanyCategory.CompanyCategoryName,
                InvoiceStatus = d.InvoiceStatus.InvoiceName,
                InvoiceType = d.InvoiceType.InvoiceTypeName
            }).ToList();

            return invoiceDetails;
        }

    }
}

