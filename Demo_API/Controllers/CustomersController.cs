using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo_API.Data;
using Demo_API.Model;
using Demo_API.Model.Dto;
using AutoMapper;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CustomersController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<CustomerDtoGet>>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
          var customers= await _context.Customers
                .Include(cus=>cus.Invoices)
                .Include(cus=>cus.Company)
                .Select(cus=>new CustomerDtoGet
                {
                    Id = cus.Id,
                    CustomerName = cus.CustomerName,
                    CustomerEmail = cus.CustomerEmail,
                    CustomerPhone = cus.CustomerPhone,
                    CustomerCity = cus.CustomerCity,
                    CustomerAddress = cus.CustomerAddress,
                    CustomerSex = cus.CustomerSex,
                    IDCardMadeDate = cus.IDCardMadeDate,
                    IdentityCardNumber = cus.IdentityCardNumber,
                    CompanyId= cus.CompanyId,
                    IsActive = cus.IsActive,
                    Company=_mapper.Map<CompanyDtoUpdate> (cus.Company),
                    Invoices=_mapper.Map<List<InvoiceUpdate>>( cus.Invoices)
                                  
                })
                .Where(x => x.IsActive.Equals(true)).ToListAsync();
            var response = new BaseResponse<IEnumerable<CustomerDtoGet>>
            {
                Message = "success",
                Data = customers,
                StatusCode = 200,
            };
            return Ok(response);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CustomerDtoGet>>> GetCustomer(int id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers
                .Include(cus => cus.Invoices)
                .Include(cus => cus.Company)
                .Select(cus => new CustomerDtoGet
                {
                    Id = cus.Id,
                    CustomerName = cus.CustomerName,
                    CustomerEmail = cus.CustomerEmail,
                    CustomerPhone = cus.CustomerPhone,
                    CustomerCity = cus.CustomerCity,
                    CustomerAddress = cus.CustomerAddress,
                    CustomerSex = cus.CustomerSex,
                    IDCardMadeDate = cus.IDCardMadeDate,
                    IdentityCardNumber = cus.IdentityCardNumber,
                    IsActive = cus.IsActive,
                    Company = _mapper.Map<CompanyDtoUpdate>(cus.Company),
                    Invoices = _mapper.Map<List<InvoiceUpdate>>(cus.Invoices)

                })
                .Where(x => x.IsActive.Equals(true) && x.Id.Equals(id)).FirstAsync();

            if (customer == null)
            {
                return NotFound();
            }
            var response=new BaseResponse<CustomerDtoGet>
            {
                Data=customer,
                Message="success",
                StatusCode=200
            };
            return Ok(response);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerUpdate customerUpdate)
        {
           var customer= _mapper.Map<Customer>(customerUpdate);
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDto customerDto)
        {
            var customer=_mapper.Map<Customer>(customerDto);
            if (_context.Customers == null)
            {
              return Problem("Entity set 'DataContext.Customers'  is null.");
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.Where(x=>x.IsActive.Equals(true) && x.Id.Equals(id) ).FirstAsync();
            if (customer == null)
            {
                return NotFound();
            }
            customer.IsActive=false;
           /* _context.Customers.Remove(customer);*/
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
