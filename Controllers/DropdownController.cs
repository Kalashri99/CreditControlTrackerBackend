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
        public async Task<IActionResult> GetInvoiceDetail(int pageNumber=1,int pageSize=100)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var InvoiceDetails = await _dropdownRepository.GetAllInvoiceDetails();
            var pagedItems=InvoiceDetails.Skip((pageNumber-1)*pageSize).Take(pageSize);
            var totalCount=InvoiceDetails.Count();
            var totalPages=(int)Math.Ceiling((double)totalCount/pageSize);
            var response = new
            {
                TotalPages = totalPages,
                TotalCount = totalCount,
                Items = pagedItems,

            };
            return Ok(response);
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
        public async Task<IActionResult> GetInvoiceDetails(string Entity, string CompanyCategory, string InvoiceType, string Customer,int pageNumber=1,int pageSize=100 )
        {
            var invoiceDetails =await _dropdownRepository.GetInvoiceDetails(Entity,CompanyCategory,InvoiceType,Customer);
            var pagedItems = invoiceDetails.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            var totalCount = invoiceDetails.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var response = new
            {
                Items = pagedItems,
                TotalCount=totalCount,
                TotalPages=totalPages
            };
            return Ok(response);
        }

        [HttpGet("Customer/{id}")]
        public async Task<IActionResult> GetCustomerInvoice(int id)
        {
            var customer = await _dropdownRepository.GetCustomerInvoice(id);



            if (customer == null)
            {
                return NotFound();
            }



            return Ok(customer);
        }

        [HttpGet("Cust/{id}")]
        public async Task<IActionResult> GetPredictions(int id)
        {
            var customer = await _dropdownRepository.GetPredictions(id);



            if (customer == null)
            {
                return NotFound();
            }



            return Ok(customer);
        }

        [HttpGet("TotalAnalysis")]
        public async Task<IActionResult> GetTotalAnalysis()
        {
            var analysis = await _dropdownRepository.GetTotalAnalysis();



            if (analysis == null)
            {
                return NotFound();
            }



            return Ok(analysis);
        }
    }
    }
