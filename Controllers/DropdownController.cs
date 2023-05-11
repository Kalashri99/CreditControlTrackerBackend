using CreditContolTrackerAPIs.Interface;
using CreditControlTrackerAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditContolTrackerAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditControlController : ControllerBase
    {

        private readonly IDropdownRepository _dropdownRepository;
  //      private readonly IMapper _mapper;
        public CreditControlController(IDropdownRepository dropdownRepository)
        {
            _dropdownRepository = dropdownRepository;
     //       _mapper = mapper;
        }

        [HttpGet("InvoiceDetail")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceDetail>))]
        public async Task<IActionResult> GetInvoiceDetail()
        {
            var InvoiceDetails = _dropdownRepository.GetInvoiceDetails().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(InvoiceDetails);
        }




        [HttpGet("Entity")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> GetEntity()
        {
            var Entities = _dropdownRepository.GetEntity();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Entities);
        }


        [HttpGet("Customer")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IActionResult> GetCustomer()
        {
            var Customers = _dropdownRepository.GetCustomer();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Customers);
        }

        
        [HttpGet("CompanyCategory")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CompanyCategory>))]
        public async Task<IActionResult> GetCompanyCategory()
        {
            var CompanyCategories = _dropdownRepository.GetCompanyCategory();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(CompanyCategories);
        }

        [HttpGet("InvoiceType")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceType>))]
        public async Task<IActionResult> GetInvoiceType()
        {
            var InvoiceTypes = _dropdownRepository.GetInvoiceType();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(InvoiceTypes);
        }
        
        }
    }
