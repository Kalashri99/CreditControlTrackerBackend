
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
        ApplicationDbContextFactory _contextFactory;
        public excelGrid(ApplicationDbContext context, ApplicationDbContextFactory contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;

        }

        public object[,] datatable()
        {
            DataTable dataTable = new DataTable();
            string filePath = @"D:\newSheet.xlsx";
            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.ActiveSheet;



            // Get the used range of the worksheet
            Range usedRange = worksheet.UsedRange;



            // Get the number of rows and columns in the worksheet
            int rowCount = usedRange.Rows.Count;
            int colCount = usedRange.Columns.Count;
            object[,] data = (object[,])usedRange.Value;
            //Console.WriteLine(rowCount);
            // Console.WriteLine(colCount);
            /*
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
            for (int row = 10; row <= 1000; row++) // assuming the first row is a header row
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
            */
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

            return data;
        }

        long stringToLong(string data)
        {
            return long.TryParse(data, out long var1) ? var1 : 0;
        }

        int stringToInt(string data)
        {
            return int.TryParse(data, out int var1) ? var1 : 0;
        }

        DateTime? stringToDateTime(string data)
        {
            // DateTime? date = !string.IsNullOrEmpty(data) ? DateTime.Parse(data) : null;
            DateTime? date;
            if (!string.IsNullOrEmpty(data) && DateTime.TryParse(data, out DateTime parsedDate))
            {
                date = parsedDate;
            }
            else
            {
                date = null;
            }

            return date;
        }


        public void InsertData()
        {
            object[,] objectArray = datatable();
            int batchSize = 500;
            int totalRecords = objectArray.GetLength(0); // Get the total number of records
            for (int startIndex = 10; startIndex < totalRecords; startIndex += batchSize)
            {
                int endIndex = Math.Min(startIndex + batchSize, totalRecords);
                List<InvoiceDetail> InsertInvoiceDetailBulk = new List<InvoiceDetail>();
                List<InvoiceDetail> UpdateInvoiceDetailsBulk = new List<InvoiceDetail>();
                List<Receipt> UpdateReceiptBulk = new List<Receipt>();
                for (int row = startIndex; row <= endIndex; row++)
                {
                    string InvoiceNo = objectArray[row, 4]?.ToString();
                    if (InvoiceNo == " " || InvoiceNo == "0")
                        continue;
                    int entityId = AddEntity(objectArray[row, 1]?.ToString());
                    int accountTypeId = AddAccountType(objectArray[row, 40]?.ToString());
                    int invoiceTypeId = AddInvoiceTypes(objectArray[row, 34]?.ToString());
                    int invoiceStatusId = AddInvoiceStatus(objectArray[row, 13]?.ToString());
                    int agingId = AddAging(objectArray[row, 14]?.ToString());
                    int companyCategoryId = AddCompanyCategory(objectArray[row, 49]?.ToString());
                    int customerId = AddCustomer(objectArray[row, 2]?.ToString(), objectArray[row, 3]?.ToString());
                    int receiptId = AddReceipt(stringToDateTime(objectArray[row, 16]?.ToString()), stringToLong(objectArray[row, 17]?.ToString()),
                       stringToLong(objectArray[row, 18]?.ToString()), objectArray[row, 19]?.ToString(), objectArray[row, 20]?.ToString(), objectArray[row, 21]?.ToString());
                    // string invNo=row[3].ToString(); 
                    var existingInvoiceDetail = _context.InvoiceDetails.FirstOrDefault(i => i.InvoiceNo == InvoiceNo);
                    //  string InvoiceId;
                    if (existingInvoiceDetail == null)
                    {
                        var invoiceDetail = new InvoiceDetail()
                        {
                            InvoiceNo = InvoiceNo,
                            PoNo = objectArray[row, 5]?.ToString(),
                            InvoiceDate = stringToDateTime(objectArray[row, 7]?.ToString()),
                            PaymentTerm = stringToInt(objectArray[row, 8]?.ToString()),
                            DueDate = stringToDateTime(objectArray[row, 9]?.ToString()),
                            BalanceInCurrency = stringToLong(objectArray[row, 10]?.ToString()),
                            Currency = objectArray[row, 11]?.ToString(),
                            Usdbalance = stringToLong(objectArray[row, 12]?.ToString()),
                            Provisioning = objectArray[row, 15]?.ToString(),
                            BalanceInUsd = stringToLong(objectArray[row, 23]?.ToString()),
                            Category = objectArray[row, 26]?.ToString(),
                            CreditNoteDiscounts = stringToLong(objectArray[row, 24]?.ToString()),
                            CreditUsdamount = stringToLong(objectArray[row, 25]?.ToString()),
                            AccountManager = objectArray[row, 27]?.ToString(),
                            Cell = objectArray[row, 28]?.ToString(),
                            BrnFacTuName = objectArray[row, 29]?.ToString(),
                            NewBu = objectArray[row, 30]?.ToString(),
                            ArPoc = objectArray[row, 31]?.ToString(),
                            NewDu = objectArray[row, 32]?.ToString(),
                            NewOu = objectArray[row, 33]?.ToString(),
                            InvoiceTypeId = invoiceTypeId,
                            ContractPartyName = objectArray[row, 35]?.ToString(),
                            ProjectContractId = objectArray[row, 36]?.ToString(),
                            InvoiceManager = objectArray[row, 37]?.ToString(),
                            SalesPocasperIms = objectArray[row, 38]?.ToString(),
                            OtherReference = objectArray[row, 39]?.ToString(),
                            DeliveryPartner = objectArray[row, 41]?.ToString(),
                            DeliveryHead = objectArray[row, 42]?.ToString(),
                            SalesPoc = objectArray[row, 43]?.ToString(),
                            SalesVp = objectArray[row, 44]?.ToString(),
                            FusionAccountName = objectArray[row, 46]?.ToString(),
                            FusionAccountNumber = stringToLong(objectArray[row, 45]?.ToString()),
                            UpdatedSalesPoc = objectArray[row, 47]?.ToString(),
                            UpdatedSalesVp = objectArray[row, 48]?.ToString(),
                            AccountTypeId = accountTypeId,
                            CustomerId = customerId,
                            CompanyCategoryId = companyCategoryId,
                            InvoiceStatusId = invoiceStatusId,
                            AgingId = agingId,
                            EntityId = entityId

                        };
                        InsertInvoiceDetailBulk.Add(invoiceDetail);
                        //  _context.InvoiceDetails.Add(invoiceDetail);
                        // _context.SaveChanges();

                    }
                    else
                    {

                        // existingInvoiceDetail.InvoiceNo = InvoiceNo;
                        existingInvoiceDetail.PoNo = objectArray[row, 5]?.ToString();
                        existingInvoiceDetail.InvoiceDate = stringToDateTime(objectArray[row, 7]?.ToString());
                        existingInvoiceDetail.DueDate = stringToDateTime(objectArray[row, 9]?.ToString());
                        existingInvoiceDetail.BalanceInCurrency = stringToLong(objectArray[row, 10]?.ToString());
                        existingInvoiceDetail.Currency = objectArray[row, 11]?.ToString();
                        existingInvoiceDetail.Usdbalance = stringToLong(objectArray[row, 12]?.ToString());
                        existingInvoiceDetail.Provisioning = objectArray[row, 15]?.ToString();
                        existingInvoiceDetail.BalanceInUsd = stringToLong(objectArray[row, 23]?.ToString());
                        existingInvoiceDetail.CreditNoteDiscounts = stringToLong(objectArray[row, 24]?.ToString());
                        existingInvoiceDetail.CreditUsdamount = stringToLong(objectArray[row, 25]?.ToString());
                        existingInvoiceDetail.AccountManager = objectArray[row, 27]?.ToString();
                        existingInvoiceDetail.Cell = objectArray[row, 28]?.ToString();
                        existingInvoiceDetail.BrnFacTuName = objectArray[row, 29]?.ToString();
                        existingInvoiceDetail.NewBu = objectArray[row, 30]?.ToString();
                        existingInvoiceDetail.ArPoc = objectArray[row, 31]?.ToString();
                        existingInvoiceDetail.NewDu = objectArray[row, 32]?.ToString();
                        existingInvoiceDetail.NewOu = objectArray[row, 33]?.ToString();
                        existingInvoiceDetail.InvoiceTypeId = invoiceTypeId;
                        existingInvoiceDetail.ContractPartyName = objectArray[row, 35]?.ToString();
                        existingInvoiceDetail.ProjectContractId = objectArray[row, 36]?.ToString();
                        existingInvoiceDetail.InvoiceManager = objectArray[row, 37]?.ToString();
                        existingInvoiceDetail.SalesPocasperIms = objectArray[row, 38]?.ToString();
                        existingInvoiceDetail.OtherReference = objectArray[row, 39]?.ToString();
                        existingInvoiceDetail.DeliveryPartner = objectArray[row, 41]?.ToString();
                        existingInvoiceDetail.DeliveryHead = objectArray[row, 42]?.ToString();
                        existingInvoiceDetail.SalesPoc = objectArray[row, 43]?.ToString();
                        existingInvoiceDetail.SalesVp = objectArray[row, 44]?.ToString();
                        existingInvoiceDetail.FusionAccountName = objectArray[row, 45]?.ToString();
                        existingInvoiceDetail.FusionAccountNumber = stringToLong(objectArray[row, 46]?.ToString());
                        existingInvoiceDetail.UpdatedSalesPoc = objectArray[row, 47]?.ToString();
                        existingInvoiceDetail.UpdatedSalesVp = objectArray[row, 48]?.ToString();
                        existingInvoiceDetail.AccountTypeId = accountTypeId;
                        existingInvoiceDetail.CustomerId = customerId;
                        existingInvoiceDetail.CompanyCategoryId = companyCategoryId;
                        existingInvoiceDetail.InvoiceStatusId = invoiceStatusId;
                        existingInvoiceDetail.AgingId = agingId;
                        existingInvoiceDetail.EntityId = entityId;
                        //_context.InvoiceDetails.Update(existingInvoiceDetail);
                        // _context.SaveChanges();

                        UpdateInvoiceDetailsBulk.Add(existingInvoiceDetail);


                    }
                    var receipt = _context.Receipts.FirstOrDefault(r => r.ReceiptId == receiptId);
                    if (receipt != null)
                    {
                        receipt.InvoiceNo = InvoiceNo;
                        UpdateReceiptBulk.Add(receipt);
                    }
                  


                }
                if(UpdateInvoiceDetailsBulk.Any())
                UpdateInvoiceDetailsBatchData(UpdateInvoiceDetailsBulk);
                if (InsertInvoiceDetailBulk.Any())
                    InsertInvoiceDetailsBatchData(InsertInvoiceDetailBulk);
                if (UpdateReceiptBulk.Any())
              UpdateRecieptBatchData(UpdateReceiptBulk);
              

            }

        }

        public void UpdateInvoiceDetailsBatchData(List<InvoiceDetail> batchData)
        {
            using (var _context = _contextFactory.Create())
            {
                _context.InvoiceDetails.UpdateRange(batchData);
                _context.SaveChanges();
            }
        }
        public void UpdateRecieptBatchData(List<Receipt> batchData)
        {
            using (var _context = _contextFactory.Create())
            {
                _context.Receipts.UpdateRange(batchData);
                _context.SaveChanges();
            }
        }
        public void InsertInvoiceDetailsBatchData(List<InvoiceDetail> batchData)
        {
            using (var _context = _contextFactory.Create())
            {
                _context.InvoiceDetails.AddRange(batchData);
                _context.SaveChanges();
            }
        }

        public async Task GetBatchData(object[,] objectArray,int startIndex, int endIndex)
        { 
            List<InvoiceDetail> InsertInvoiceDetailBulk=new List<InvoiceDetail>();
            List<InvoiceDetail> UpdateInvoiceDetailsBulk=new List<InvoiceDetail>();
            List<Receipt> UpdateReceiptBulk=new List<Receipt>();
            for (int row = startIndex; row <=endIndex ; row++)
            {
                string InvoiceNo = objectArray[row, 4]?.ToString();
                    if (InvoiceNo == " " || InvoiceNo == "0")
                        continue;
                int entityId = AddEntity(objectArray[row,1]?.ToString());
                int accountTypeId = AddAccountType(objectArray[row, 40]?.ToString());
                int invoiceTypeId = AddInvoiceTypes(objectArray[row, 34]?.ToString());
                int invoiceStatusId = AddInvoiceStatus(objectArray[row, 13]?.ToString());
                int agingId = AddAging(objectArray[row, 14]?.ToString());
                int companyCategoryId = AddCompanyCategory(objectArray[row, 49]?.ToString());
                int customerId = AddCustomer(objectArray[row, 2]?.ToString(), objectArray[row, 3]?.ToString());
                 int receiptId = AddReceipt(stringToDateTime(objectArray[row, 16]?.ToString()), stringToLong(objectArray[row, 17]?.ToString()),
                    stringToLong(objectArray[row, 18]?.ToString()), objectArray[row, 19]?.ToString(), objectArray[row, 20]?.ToString(), objectArray[row, 21]?.ToString());
               // string invNo=row[3].ToString(); 
                var existingInvoiceDetail = _context.InvoiceDetails.FirstOrDefault(i=>i.InvoiceNo==InvoiceNo);
              //  string InvoiceId;
                if (existingInvoiceDetail == null)
                {
                    var invoiceDetail = new InvoiceDetail()
                    {
                        InvoiceNo = InvoiceNo,
                        PoNo = objectArray[row,5]?.ToString(),
                        InvoiceDate = stringToDateTime(objectArray[row, 7]?.ToString()),
                        PaymentTerm=stringToInt(objectArray[row,8]?.ToString()),
                        DueDate =stringToDateTime(objectArray[row, 9]?.ToString()),
                        BalanceInCurrency = stringToLong(objectArray[row,10]?.ToString()),
                        Currency = objectArray[row, 11]?.ToString(),
                        Usdbalance=stringToLong(objectArray[row, 12]?.ToString()),
                        Provisioning=objectArray[row,15]?.ToString(),
                        BalanceInUsd=stringToLong(objectArray[row, 23]?.ToString()),
                        Category=objectArray[row, 26]?.ToString(),
                        CreditNoteDiscounts=stringToLong(objectArray[row, 24]?.ToString()),
                        CreditUsdamount=stringToLong(objectArray[row, 25]?.ToString()),
                        AccountManager= objectArray[row, 27]?.ToString(),
                        Cell= objectArray[row, 28]?.ToString(),
                        BrnFacTuName=objectArray[row,29]?.ToString(),
                        NewBu= objectArray[row, 30]?.ToString(),
                        ArPoc= objectArray[row, 31]?.ToString(),
                        NewDu= objectArray[row, 32]?.ToString(),
                        NewOu= objectArray[row, 33]?.ToString(),
                        InvoiceTypeId=invoiceTypeId,
                        ContractPartyName= objectArray[row, 35]?.ToString(),
                        ProjectContractId= objectArray[row, 36]?.ToString(),
                        InvoiceManager= objectArray[row, 37]?.ToString(),
                        SalesPocasperIms= objectArray[row, 38]?.ToString(),
                        OtherReference= objectArray[row, 39]?.ToString(),
                        DeliveryPartner= objectArray[row, 41]?.ToString(),
                        DeliveryHead= objectArray[row, 42]?.ToString(),
                        SalesPoc= objectArray[row, 43]?.ToString(),
                        SalesVp=objectArray[row,44]?.ToString(),
                        FusionAccountName= objectArray[row, 46]?.ToString(),
                        FusionAccountNumber=stringToLong(objectArray[row, 45]?.ToString()),
                        UpdatedSalesPoc= objectArray[row, 47]?.ToString(),
                        UpdatedSalesVp= objectArray[row, 48]?.ToString(),
                        AccountTypeId=accountTypeId,
                        CustomerId=customerId,
                        CompanyCategoryId=companyCategoryId,
                        InvoiceStatusId=invoiceStatusId,
                        AgingId=agingId,
                        EntityId=entityId

                    };
                   InsertInvoiceDetailBulk.Add(invoiceDetail);
                  //  _context.InvoiceDetails.Add(invoiceDetail);
                   // _context.SaveChanges();
                   
                }
                else
                {

                   // existingInvoiceDetail.InvoiceNo = InvoiceNo;
                    existingInvoiceDetail.PoNo = objectArray[row, 5]?.ToString();
                         existingInvoiceDetail.InvoiceDate = stringToDateTime(objectArray[row, 7]?.ToString());
 existingInvoiceDetail.DueDate = stringToDateTime(objectArray[row, 9]?.ToString());
 existingInvoiceDetail.BalanceInCurrency = stringToLong(objectArray[row, 10]?.ToString());
                         existingInvoiceDetail.Currency = objectArray[row, 11]?.ToString();
                         existingInvoiceDetail.Usdbalance = stringToLong(objectArray[row, 12]?.ToString());
                         existingInvoiceDetail.Provisioning = objectArray[row, 15]?.ToString();
                         existingInvoiceDetail.BalanceInUsd = stringToLong(objectArray[row, 23]?.ToString());
                         existingInvoiceDetail.CreditNoteDiscounts = stringToLong(objectArray[row, 24]?.ToString());
                         existingInvoiceDetail.CreditUsdamount = stringToLong(objectArray[row, 25]?.ToString());
                         existingInvoiceDetail.AccountManager = objectArray[row, 27]?.ToString();
                        existingInvoiceDetail.Cell = objectArray[row, 28]?.ToString();
                        existingInvoiceDetail.BrnFacTuName = objectArray[row, 29]?.ToString();
                         existingInvoiceDetail.NewBu = objectArray[row, 30]?.ToString();
                         existingInvoiceDetail.ArPoc = objectArray[row, 31]?.ToString();
                         existingInvoiceDetail.NewDu = objectArray[row, 32]?.ToString();
                         existingInvoiceDetail.NewOu = objectArray[row, 33]?.ToString();
                        existingInvoiceDetail.InvoiceTypeId = invoiceTypeId;
                        existingInvoiceDetail.ContractPartyName = objectArray[row, 35]?.ToString();
                        existingInvoiceDetail.ProjectContractId = objectArray[row, 36]?.ToString();
                         existingInvoiceDetail.InvoiceManager = objectArray[row, 37]?.ToString();
 existingInvoiceDetail.SalesPocasperIms = objectArray[row, 38]?.ToString();
 existingInvoiceDetail.OtherReference = objectArray[row, 39]?.ToString();
                      existingInvoiceDetail.DeliveryPartner = objectArray[row, 41]?.ToString();
                     existingInvoiceDetail.DeliveryHead = objectArray[row, 42]?.ToString();
                     existingInvoiceDetail.SalesPoc = objectArray[row, 43]?.ToString();
                      existingInvoiceDetail.SalesVp = objectArray[row, 44]?.ToString();
                         existingInvoiceDetail.FusionAccountName = objectArray[row, 45]?.ToString();
                        existingInvoiceDetail.FusionAccountNumber = stringToLong(objectArray[row, 46]?.ToString());
                        existingInvoiceDetail.UpdatedSalesPoc = objectArray[row, 47]?.ToString();
                        existingInvoiceDetail.UpdatedSalesVp = objectArray[row, 48]?.ToString();
                         existingInvoiceDetail.AccountTypeId = accountTypeId;
                        existingInvoiceDetail.CustomerId = customerId;
                        existingInvoiceDetail.CompanyCategoryId = companyCategoryId;
                       existingInvoiceDetail.InvoiceStatusId = invoiceStatusId;
                       existingInvoiceDetail.AgingId = agingId;
                      existingInvoiceDetail.EntityId = entityId;
                    //_context.InvoiceDetails.Update(existingInvoiceDetail);
                   // _context.SaveChanges();

                    UpdateInvoiceDetailsBulk.Add(existingInvoiceDetail);
                  

                }
                    var receipt=_context.Receipts.FirstOrDefault(r=>r.ReceiptId== receiptId);   
                if (receipt!=null)
                {
                    receipt.InvoiceNo = InvoiceNo;
                }
                UpdateReceiptBulk.Add(receipt);


            }

           
            
        }
        public int AddEntity(string Name)
        {
            int entityId;

            using (var context = _contextFactory.Create())
            { 
            // Check if the data already exists in the database
            var existingentity = context.Entities.FirstOrDefault(t => t.EntityName == Name);
            if (existingentity == null)
            {
                var entity = new Entity
                {
                    EntityName = Name
                    // add other properties here...
                };
                // Insert a new record into the ArPOC table
                context.Entities.Add(entity);
                context.SaveChanges();
                entityId = entity.EntityId;


            }
            else
                entityId = existingentity.EntityId;
        }

            return entityId;
        }
        public int AddInvoiceStatus(string Name)
        {
            int invoiceStatusId;
            using (var context = _contextFactory.Create())
            {

                // Check if the data already exists in the database
                var existinginvoiceStatus = context.InvoiceStatuses.FirstOrDefault(t => t.InvoiceName == Name);
                if (existinginvoiceStatus == null)
                {
                    var invoiceStatus = new InvoiceStatus
                    {
                        InvoiceName = Name
                        // add other properties here...
                    };
                    // Insert a new record into the InvoiceStatus table
                    context.InvoiceStatuses.Add(invoiceStatus);
                    context.SaveChanges();
                    invoiceStatusId = invoiceStatus.InvoiceStatusId;


                }

                else
                    invoiceStatusId = existinginvoiceStatus.InvoiceStatusId;
            }
            return invoiceStatusId;
        }
        public int AddInvoiceTypes(string Name)
        {
            int invoiceTypesId;

            using (var context = _contextFactory.Create())
            {
                // Check if the data already exists in the database
                var existinginvoiceTypes = context.InvoiceTypes.FirstOrDefault(t => t.InvoiceTypeName == Name);
                if (existinginvoiceTypes == null)
                {
                    var invoiceTypes = new InvoiceType
                    {
                        InvoiceTypeName = Name
                        // add other properties here...
                    };
                    // Insert a new record into the InvoiceTypes table
                    context.InvoiceTypes.Add(invoiceTypes);
                    context.SaveChanges();
                    invoiceTypesId = invoiceTypes.InvoiceTypeId;


                }
                else
                    invoiceTypesId = existinginvoiceTypes.InvoiceTypeId;
            }
            return invoiceTypesId;
        }
        public int AddAccountType(string name)
        {
            int AccountTypeId;

            using (var context = _contextFactory.Create())
            { 
            // Check if the data already exists in the database
            var existingAccountType = context.AccountTypes.FirstOrDefault(t => t.AccountTypeName == name);
            if (existingAccountType == null)
            {
                var accountType = new AccountType
                {
                    AccountTypeName = name
                    // add other properties here...
                };
                // Insert a new record into the InvoiceTypes table
                context.AccountTypes.Add(accountType);
                context.SaveChanges();

                AccountTypeId = accountType.AccountTypeId;

            }

            else
                AccountTypeId = existingAccountType.AccountTypeId;
        }

            return AccountTypeId;
        }
        public int AddAging(string name)
        {
            int AgingId;
            using (var context = _contextFactory.Create())
            {

                // Check if the data already exists in the database
                var existingAging = context.Agings.FirstOrDefault(t => t.AgingName == name);
                if (existingAging == null)
                {
                    var aging = new Aging
                    {
                        AgingName = name
                        // add other properties here...
                    };
                    // Insert a new record into the InvoiceTypes table
                    context.Agings.Add(aging);
                    context.SaveChanges();

                    AgingId = aging.AgingId;

                }

                else
                    AgingId = existingAging.AgingId;
            }
            return AgingId;
        }

        public int AddCustomer(string Name, string AccNo)
        {
            int customerId;

            using (var context = _contextFactory.Create())
            {
                // Check if the data already exists in the database
                var existingcostumer = context.Customers.FirstOrDefault(t => t.CustomerName == Name && t.CustomerAccountNumber == AccNo);
                if (existingcostumer == null)
                {
                    var costumer = new Customer
                    {
                        CustomerName = Name,
                        CustomerAccountNumber = AccNo
                        // add other properties here...
                    };
                    // Insert a new record into the ArPOC table
                    context.Customers.Add(costumer);
                    context.SaveChanges();
                    customerId = costumer.CustomerId;


                }
                else
                    customerId = existingcostumer.CustomerId;
            }
            return customerId;
        }
        public int AddCompanyCategory(string Name)
        {
            int companyCategoryId;

            using (var context = _contextFactory.Create())
            {
                // Check if the data already exists in the database
                var existingcompanyCategory = context.CompanyCategories.FirstOrDefault(t => t.CompanyCategoryName == Name);
                if (existingcompanyCategory == null)
                {
                    var companyCategory = new CompanyCategory
                    {
                        CompanyCategoryName = Name
                        // add other properties here...
                    };
                    // Insert a new record into the ArPOC table
                    context.CompanyCategories.Add(companyCategory);
                    context.SaveChanges();
                    companyCategoryId = companyCategory.CompanyCategoryId;


                }
                else
                    companyCategoryId = existingcompanyCategory.CompanyCategoryId;
            }
            return companyCategoryId;
        }
        public int AddReceipt(DateTime? date, long recOrigCurrAmount, long amountInUsd, string receivedIn, string checkWire, string bankName)
        {
            int receiptId;
            using (var context = _contextFactory.Create())
            {

                var receipt = new Receipt
                {
                    Date = date,
                    RecOrigCurrAmount = recOrigCurrAmount,
                    AmountInUsd = amountInUsd,
                    ReceivedIn = receivedIn,
                    CheckWire = checkWire,
                    BankName = bankName
                    // add other properties here...
                };
                // Insert a new record into the ArPOC table
                context.Receipts.Add(receipt);
                context.SaveChanges();
                receiptId = receipt.ReceiptId;
            }
            return receiptId;
        }

    }
}

