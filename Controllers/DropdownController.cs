using CreditContolTrackerAPIs.Interface;
using CreditControlTrackerAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CreditContolTrackerAPIs.Dto;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditContolTrackerAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditControlController : ControllerBase
    {

        private readonly IDropdownRepository _dropdownRepository;
        private readonly IMapper _mapper;
        public CreditControlController(IDropdownRepository dropdownRepository, IMapper mapper)
        {
            _dropdownRepository = dropdownRepository;
            _mapper = mapper;
        }

        [HttpGet("AllInvoiceDetail")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceDetail>))]
        public async Task<IActionResult> GetInvoiceDetail()
        {
            var InvoiceDetails = _dropdownRepository.GetAllInvoiceDetails().ToList();
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

        //[HttpGet("api/invoiceDetails")]
        //public IActionResult GetInvoiceDetails(string Entity, string CompanyCategory, string InvoiceType, string Customers)
        //{
        //    var invoiceDetails = _dropdownRepository.GetInvoiceDetails(Entity, CompanyCategory, InvoiceType, Customers);

        //    if (invoiceDetails == null || !invoiceDetails.Any())
        //    {
        //        return NotFound();
        //    }

        //    return Ok(invoiceDetails);
        //}

        //[HttpGet("AllInvoiceDetails")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceType>))]
        //public async Task<IActionResult> GetAllInvoiceDetails()
        //{
        //    var InvoiceDetails = _dropdownRepository.GetAllInvoiceDetails();
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    return Ok(InvoiceDetails);
        //}


        [HttpGet("api/invoiceDetails")]
        public IActionResult GetInvoiceDetails(string Entity, string CompanyCategory, string InvoiceType, string Customer)
        {
            var invoiceDetails = _dropdownRepository.GetInvoiceDetails(Entity,CompanyCategory,InvoiceType,Customer);

            return Ok(invoiceDetails);
        }



    }
    }
