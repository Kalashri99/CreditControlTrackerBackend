
using CreditControlTrackerAPIs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditControlTrackerAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        excelGrid _excel;
       public ExcelController(excelGrid excel)
        {
            _excel=excel;
        }

    [HttpPost]
    [Route("InsertDataIntoDatabase")]
    public async Task<string> InsertDataFromExcel()
        {
           await _excel.InsertData();
            return "Data successfully Inserted";
        }
   

    }
}
