
using CreditContolTrackerAPIs.Models;

namespace CreditContolTrackerAPIs.Dto
{
    public class InvoiceDetailsDto
    {
        public string Entity { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string InvoiceNo { get; set; }

        public string PoNo { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? DueDate { get; set; }

        public long? BalanceInCurrency { get; set; }

        public string? Currency { get; set; }

        public long? Usdbalance { get; set; }

        public string? Provisioning { get; set; }

        public long? BalanceInUsd { get; set; }

        public long? CreditNoteDiscounts { get; set; }

        public long? CreditUsdamount { get; set; }

        public string? AccountManager { get; set; }

        public string Cell { get; set; }

        public string BrnFacTuName { get; set; }

        public string NewBu { get; set; }

        public string ArPoc { get; set; }

        public string NewDu { get; set; }

        public string NewOu { get; set; }

        public int InvoiceTypeId { get; set; }

        public string ContractPartyName { get; set; }

        public string ProjectContractId { get; set; }

        public string InvoiceManager { get; set; }

        public string SalesPocasperIms { get; set; }

        public string OtherReference { get; set; }

        public string DeliveryPartner { get; set; }

        public string DeliveryHead { get; set; }

        public string SalesPoc { get; set; }

        public string SalesVp { get; set; }

        public long? FusionAccountNumber { get; set; }

        public string FusionAccountName { get; set; }

        public string UpdatedSalesPoc { get; set; }

        public string UpdatedSalesVp { get; set; }
        public string AccountType { get; set; }
        

        public string Aging { get; set; }

        public string CompanyCategory { get; set; }

        public string InvoiceStatus { get; set; }

        public string InvoiceType { get; set; }
        public int? PaymentTerm { get; set; }



        public string? Category { get; set; }
        public Receipt Receipt { get; set; }
        public int ReceiptId { get; set; }
        public DateTime? Date { get; set; }
        public long? RecOrigCurrAmount { get; set; }
        public long? AmountInUsd { get; set; }
        public string? ReceivedIn { get; set; }
        public string? CheckWire { get; set; }
        public string? BankName { get; set; }
        public long Column8 { get; set; }

    }

    //public class AccountTypeDto
    //{
    //    public string? AccountTypeName { get; set; }
    //}
}
