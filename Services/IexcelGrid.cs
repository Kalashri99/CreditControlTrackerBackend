using System.Data;

namespace CreditControlTrackerAPIs.Services
{
    public interface IexcelGrid
    {

        public DataTable datatable();
        public void InsertData();

        public int AddEntity(string Name);


        public int AddInvoiceStatus(string Name);


        public int AddInvoiceTypes(string Name);


        public int AddAccountType(string name);


        public int AddAging(string name);
       

    }
}
