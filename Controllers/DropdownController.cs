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
            var InvoiceDetails = await _dropdownRepository.GetAllInvoiceDetails();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(InvoiceDetails);
        }




        [HttpGet("Entity")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> GetEntity()
        {
            var Entities = await _dropdownRepository.GetEntity();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Entities);
        }


        [HttpGet("Customer")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IActionResult> GetCustomer()
        {
            var Customers = await _dropdownRepository.GetCustomer();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Customers);
        }


        //[HttpGet("CompanyCategory")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<CompanyCategory>))]
        //public async Task<IActionResult> GetCompanyCategory()
        //{
        //    var CompanyCategories = _dropdownRepository.GetCompanyCategory();
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    return Ok(CompanyCategories);
        //}
        [HttpGet("CompanyCategory")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CompanyCategoryDto>))]
        public async Task<IActionResult> GetCompanyCategory()
        {
            var companyCategories = await _dropdownRepository.GetCompanyCategory();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(companyCategories);
        }


        [HttpGet("InvoiceType")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceType>))]
        public async Task<IActionResult> GetInvoiceType()
        {
            var InvoiceTypes =await _dropdownRepository.GetInvoiceType();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(InvoiceTypes);
        }

        [HttpGet("ColumnNames")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<String>))]
        public async Task<IActionResult> GetColumns()
        {
            var col = _dropdownRepository.GetColumns();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(col);
        }

        //[HttpGet("api/invoiceDetails")]
        //public IActionResult GetInvoiceDetails(string Entity, string CompanyCategory, string InvoiceType, string Customers)
        //{
        //    var invoiceDetails = _dropdownRepository.GetInvoiceDetails(Entity, CompanyCategory, InvoiceType, Customers);

        //    if (invoiceDetails == null || !invoiceDetails.Any())
        //    {
        //        return NotFound();
        //    }


        [HttpGet("api/invoiceDetails")]
        public async Task<IActionResult> GetInvoiceDetails(string Entity, string CompanyCategory, string InvoiceType, string Customer)
        {
            var invoiceDetails =await _dropdownRepository.GetInvoiceDetails(Entity,CompanyCategory,InvoiceType,Customer);

            return Ok(invoiceDetails);
        }

        [HttpGet("invoiceDetail/{id}")]
        public IActionResult GetInvoiceDetails(int id)
        {
            var invoiceDetails = _dropdownRepository.GetAllInvoiceDetailByCustomerId(id);

            return Ok(invoiceDetails);
        }


    }
    }
