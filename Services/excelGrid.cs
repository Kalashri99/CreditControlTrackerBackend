
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
            string filePath = @"D:\newSheet.xlsx";
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
                int customerId = AddCostumer(row[1].ToString(), row[2].ToString());




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

        public int AddCostumer(string Name, string AccNo)
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
        public int AddReceipt(DateTime date, int recOrigCurrAmount, int amountInUsd, string receivedIn, string checkWire, string bankName)
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

