﻿
using Range = Microsoft.Office.Interop.Excel.Range;
using DataTable = System.Data.DataTable;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using CreditControlTrackerAPIs.Models;
using CreditContolTrackerAPIs.Models;

namespace CreditControlTrackerAPIs.Services
{
    public class excelGrid
    {
        ApplicationDbContext _context;
        public excelGrid(ApplicationDbContext context)
        {
            _context = context;
        }

        public DataTable datatable()
        {
            DataTable dataTable = new DataTable();
            string filePath = @"D:\Credit_Control_System\Data.xlsx";
            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.ActiveSheet;



            // Get the used range of the worksheet
            Range usedRange = worksheet.UsedRange;



            // Get the number of rows and columns in the worksheet
            int rowCount = usedRange.Rows.Count;
            int colCount = usedRange.Columns.Count;
            //Console.WriteLine(rowCount);
            // Console.WriteLine(colCount);

            for (int col = 1; col <= colCount; col++)
            {
                // Console.WriteLine(((Range)worksheet.Cells[6, col]).Value.Tostring());   
                var columnNameValue = ((Range)worksheet.Cells[9, col]).Value;
                string columnName = columnNameValue != null ? columnNameValue.ToString() : String.Empty;
                Console.WriteLine(columnName);



                if (dataTable.Columns.Contains(columnName))
                    columnName += "1";
                dataTable.Columns.Add(columnName);
            }



            // Loop through the rows
            for (int row = 10; row <= 20; row++) // assuming the first row is a header row
            {

                // Create a new DataRow
                DataRow dataRow = dataTable.NewRow();



                // Loop through the columns
                for (int col = 1; col <= colCount; col++)
                {
                    // Get the value in the current cell
                    var value = ((Range)usedRange.Cells[row, col]).Value;



                    // Set the value in the corresponding column of the DataRow
                    dataRow[col - 1] = value;
                }



                // Add the DataRow to the DataTable
                dataTable.Rows.Add(dataRow);
            }

            // Close the workbook and release the resources

            workbook.Close();
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            /*
            int i = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                Console.Write(i + "\t");
                i++;
                // iterate through the columns
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t"); // print the value
                }
                Console.WriteLine(); // move to the next line
            }
            Console.ReadLine();
            */

            return dataTable;
        }

        long stringToLong(string data)
        {
            return long.TryParse(data, out long var1) ? var1 : 0;
        }

        DateTime? stringToDateTime(string data)
        {
            DateTime? date = !string.IsNullOrEmpty(data) ? DateTime.Parse(data) : null;
            return date;
        }
        public void InsertData()
        {
            var dataTable = datatable();
            foreach (DataRow row in dataTable.Rows)
            {
                string entityName = row[0].ToString();
                int entityId = AddEntity(entityName);
                int accountTypeId = AddAccountType(row[39].ToString());
                int invoiceTypeId = AddInvoiceTypes(row[33].ToString());
                int invoiceStatusId = AddInvoiceStatus(row[12].ToString());
                int agingId = AddAging(row[13].ToString());
                int companyCategoryId = AddCompanyCategory(row[48].ToString());
                int customerId = AddCustomer(row[1].ToString(), row[2].ToString());
                //string dateString = row[15].ToString();
               // DateTime? date = !string.IsNullOrEmpty(dateString) ? DateTime.Parse(dateString) : null;
                // Console.WriteLine("================" + row[16].GetType()+"==============="+long.Parse(row[16].ToString()));
                
                int receiptId = AddReceipt(stringToDateTime(row[15].ToString()), stringToLong(row[16]?.ToString()),
                    stringToLong(row[17]?.ToString()), row[18].ToString(), row[19].ToString(),row[20].ToString());
                string invNo=row[3].ToString(); 
                var existingInvoiceDetail = _context.InvoiceDetails.FirstOrDefault(i=>i.InvoiceNo==invNo);
                string InvoiceId;
                if (existingInvoiceDetail == null)
                {
                    var invoiceDetail = new InvoiceDetail()
                    {
                        InvoiceNo = invNo,
                        PoNo = row[4].ToString(),
                        InvoiceDate = stringToDateTime(row[6].ToString()),
                        DueDate =stringToDateTime(row[8].ToString()),
                        BalanceInCurrency = stringToLong(row[9].ToString()),
                        Currency = row[10].ToString(),
                        Usdbalance=stringToLong(row[11].ToString()),
                        Provisioning=row[14].ToString(),
                        BalanceInUsd=stringToLong(row[22].ToString()),
                        CreditNoteDiscounts=stringToLong(row[23].ToString()),
                        CreditUsdamount=stringToLong(row[24].ToString()),
                        AccountManager=row[26].ToString(),
                        Cell=row[27].ToString(),
                        BrnFacTuName=row[28].ToString(),
                        NewBu=row[29].ToString(),
                        ArPoc=row[30].ToString(),
                        NewDu=row[31].ToString(),
                        NewOu=row[32].ToString(),
                        InvoiceTypeId=invoiceTypeId,
                        ContractPartyName=row[34].ToString(),
                        ProjectContractId=row[35].ToString(),
                        InvoiceManager=row[36].ToString(),
                        SalesPocasperIms=row[37].ToString(),
                        OtherReference=row[38].ToString(),
                        DeliveryPartner=row[40].ToString(),
                        DeliveryHead=row[41].ToString(),
                        SalesPoc=row[42].ToString(),
                        SalesVp=row[43].ToString(),
                        FusionAccountName=row[44].ToString(),
                        FusionAccountNumber=stringToLong(row[45].ToString()),
                        UpdatedSalesPoc=row[46].ToString(),
                        UpdatedSalesVp=row[47].ToString(),
                        AccountTypeId=accountTypeId,
                        CustomerId=customerId,
                        CompanyCategoryId=companyCategoryId,
                        InvoiceStatusId=invoiceStatusId,
                        AgingId=agingId,
                        EntityId=entityId

                    };
                    _context.InvoiceDetails.Add(invoiceDetail);
                    _context.SaveChanges();
                    InvoiceId = invoiceDetail.InvoiceNo;
                }
                else
                {

                    existingInvoiceDetail.PoNo = row[4].ToString();
                    existingInvoiceDetail.InvoiceDate = stringToDateTime(row[6].ToString());
                    existingInvoiceDetail.DueDate = stringToDateTime(row[8].ToString());
                    existingInvoiceDetail.BalanceInCurrency = stringToLong(row[9].ToString());
                    existingInvoiceDetail.Currency = row[10].ToString();
                    existingInvoiceDetail.Usdbalance = stringToLong(row[11].ToString());
                    existingInvoiceDetail.Provisioning = row[14].ToString();
                    existingInvoiceDetail.BalanceInUsd = stringToLong(row[22].ToString());
                    existingInvoiceDetail.CreditNoteDiscounts = stringToLong(row[23].ToString());
                    existingInvoiceDetail.CreditUsdamount =stringToLong(row[24].ToString());
                    existingInvoiceDetail.AccountManager = row[26].ToString();
                    existingInvoiceDetail.Cell = row[27].ToString();
                    existingInvoiceDetail.BrnFacTuName = row[28].ToString();
                    existingInvoiceDetail.NewBu = row[29].ToString();
                    existingInvoiceDetail.ArPoc = row[30].ToString();
                    existingInvoiceDetail.NewDu = row[31].ToString();
                    existingInvoiceDetail.NewOu = row[32].ToString();
                    existingInvoiceDetail.InvoiceTypeId = invoiceTypeId;
                    existingInvoiceDetail.ContractPartyName = row[34].ToString();
                    existingInvoiceDetail.ProjectContractId = row[35].ToString();
                    existingInvoiceDetail.InvoiceManager = row[36].ToString();
                    existingInvoiceDetail.SalesPocasperIms = row[37].ToString();
                    existingInvoiceDetail.OtherReference = row[38].ToString();
                    existingInvoiceDetail.DeliveryPartner = row[40].ToString();
                    existingInvoiceDetail.DeliveryHead = row[41].ToString();
                    existingInvoiceDetail.SalesPoc = row[42].ToString();
                    existingInvoiceDetail.SalesVp = row[43].ToString();
                    existingInvoiceDetail.FusionAccountName = row[44].ToString();
                    existingInvoiceDetail.FusionAccountNumber = stringToLong(row[45].ToString());
                    existingInvoiceDetail.UpdatedSalesPoc = row[46].ToString();
                    existingInvoiceDetail.UpdatedSalesVp = row[47].ToString();
                    existingInvoiceDetail.AccountTypeId = accountTypeId;
                    existingInvoiceDetail.CustomerId = customerId;
                    existingInvoiceDetail.CompanyCategoryId = companyCategoryId;
                    existingInvoiceDetail.InvoiceStatusId = invoiceStatusId;
                    existingInvoiceDetail.AgingId = agingId;
                    existingInvoiceDetail.EntityId = entityId;

                    _context.InvoiceDetails.Update(existingInvoiceDetail);
                    _context.SaveChanges();
                    InvoiceId = existingInvoiceDetail.InvoiceNo;

                }
                    var receipt=_context.Receipts.FirstOrDefault(r=>r.ReceiptId== receiptId);   
                if (receipt!=null)
                {
                    receipt.InvoiceNo = InvoiceId;
                }




            }
        }
        public int AddEntity(string Name)
        {
            int entityId;


            // Check if the data already exists in the database
            var existingentity = _context.Entities.FirstOrDefault(t => t.EntityName == Name);
            if (existingentity == null)
            {
                var entity = new Entity
                {
                    EntityName = Name
                    // add other properties here...
                };
                // Insert a new record into the ArPOC table
                _context.Entities.Add(entity);
                _context.SaveChanges();
                entityId = entity.EntityId;


            }
            else
                entityId = existingentity.EntityId;

            return entityId;
        }
        public int AddInvoiceStatus(string Name)
        {
            int invoiceStatusId;


            // Check if the data already exists in the database
            var existinginvoiceStatus = _context.InvoiceStatuses.FirstOrDefault(t => t.InvoiceName == Name);
            if (existinginvoiceStatus == null)
            {
                var invoiceStatus = new InvoiceStatus
                {
                    InvoiceName = Name
                    // add other properties here...
                };
                // Insert a new record into the InvoiceStatus table
                _context.InvoiceStatuses.Add(invoiceStatus);
                _context.SaveChanges();
                invoiceStatusId = invoiceStatus.InvoiceStatusId;


            }
            else
                invoiceStatusId = existinginvoiceStatus.InvoiceStatusId;

            return invoiceStatusId;
        }
        public int AddInvoiceTypes(string Name)
        {
            int invoiceTypesId;


            // Check if the data already exists in the database
            var existinginvoiceTypes = _context.InvoiceTypes.FirstOrDefault(t => t.InvoiceTypeName == Name);
            if (existinginvoiceTypes == null)
            {
                var invoiceTypes = new InvoiceType
                {
                    InvoiceTypeName = Name
                    // add other properties here...
                };
                // Insert a new record into the InvoiceTypes table
                _context.InvoiceTypes.Add(invoiceTypes);
                _context.SaveChanges();
                invoiceTypesId = invoiceTypes.InvoiceTypeId;


            }
            else
                invoiceTypesId = existinginvoiceTypes.InvoiceTypeId;

            return invoiceTypesId;
        }
        public int AddAccountType(string name)
        {
            int AccountTypeId;


            // Check if the data already exists in the database
            var existingAccountType = _context.AccountTypes.FirstOrDefault(t => t.AccountTypeName == name);
            if (existingAccountType == null)
            {
                var accountType = new AccountType
                {
                    AccountTypeName = name
                    // add other properties here...
                };
                // Insert a new record into the InvoiceTypes table
                _context.AccountTypes.Add(accountType);
                _context.SaveChanges();

                AccountTypeId = accountType.AccountTypeId;

            }

            else
                AccountTypeId = existingAccountType.AccountTypeId;

            return AccountTypeId;
        }
        public int AddAging(string name)
        {
            int AgingId;


            // Check if the data already exists in the database
            var existingAging = _context.Agings.FirstOrDefault(t => t.AgingName == name);
            if (existingAging == null)
            {
                var aging = new Aging
                {
                    AgingName = name
                    // add other properties here...
                };
                // Insert a new record into the InvoiceTypes table
                _context.Agings.Add(aging);
                _context.SaveChanges();

                AgingId = aging.AgingId;

            }

            else
                AgingId = existingAging.AgingId;

            return AgingId;
        }

        public int AddCustomer(string Name, string AccNo)
        {
            int customerId;


            // Check if the data already exists in the database
            var existingcostumer = _context.Customers.FirstOrDefault(t => t.CustomerName == Name && t.CustomerAccountNumber == AccNo);
            if (existingcostumer == null)
            {
                var costumer = new Customer
                {
                    CustomerName = Name,
                    CustomerAccountNumber = AccNo
                    // add other properties here...
                };
                // Insert a new record into the ArPOC table
                _context.Customers.Add(costumer);
                _context.SaveChanges();
                customerId = costumer.CustomerId;


            }
            else
                customerId = existingcostumer.CustomerId;

            return customerId;
        }
        public int AddCompanyCategory(string Name)
        {
            int companyCategoryId;


            // Check if the data already exists in the database
            var existingcompanyCategory = _context.CompanyCategories.FirstOrDefault(t => t.CompanyCategoryName == Name);
            if (existingcompanyCategory == null)
            {
                var companyCategory = new CompanyCategory
                {
                    CompanyCategoryName = Name
                    // add other properties here...
                };
                // Insert a new record into the ArPOC table
                _context.CompanyCategories.Add(companyCategory);
                _context.SaveChanges();
                companyCategoryId = companyCategory.CompanyCategoryId;


            }
            else
                companyCategoryId = existingcompanyCategory.CompanyCategoryId;

            return companyCategoryId;
        }
        public int AddReceipt(DateTime? date, long recOrigCurrAmount, long amountInUsd, string receivedIn, string checkWire, string bankName)
        {
            int receiptId;


            var receipt = new Receipt
            {
                Date = date,
                RecOrigCurrAmount = recOrigCurrAmount,
                AmountInUsd = amountInUsd,
                ReceivedIn = receivedIn,
                BankName = bankName
                // add other properties here...
            };
            // Insert a new record into the ArPOC table
            _context.Receipts.Add(receipt);
            _context.SaveChanges();
            receiptId = receipt.ReceiptId;

            return receiptId;
        }

    }
}

