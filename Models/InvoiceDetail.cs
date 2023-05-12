using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreditControlTrackerAPIs.Models;

public partial class InvoiceDetail
{

    [Key]
    public string InvoiceNo { get; set; }

    public string PoNo { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public DateTime? DueDate { get; set; }
    public int? PaymentTerm { get; set; }

    public string? Category { get; set; }    
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

    public int AccountTypeId { get; set; }

    public int CustomerId { get; set; }

    public int InvoiceStatusId { get; set; }

    public int AgingId { get; set; }

    public int CompanyCategoryId { get; set; }

 

    public int EntityId { get; set; }

    public virtual AccountType AccountType { get; set; }

    public virtual Aging Aging { get; set; }

    public virtual CompanyCategory CompanyCategory { get; set; }

    public virtual Customer customer { get; set; }

    public virtual Entity Entity { get; set; }

    public virtual InvoiceStatus InvoiceStatus { get; set; }

    public virtual InvoiceType InvoiceType { get; set; }
    public virtual ICollection<Receipt> invoiceDetail { get; set; }


}
