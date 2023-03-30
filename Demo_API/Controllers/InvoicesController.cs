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
    public class InvoicesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public InvoicesController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
          if (_context.Invoices == null)
          {
              return NotFound();
          }
            var invoices = await _context.Invoices
           .Include(i => i.Customer)
           .Include(i => i.Company)
           .Select(i => new Invoice
           {
               InvoiceId = i.InvoiceId,
               InvoiceDate = i.InvoiceDate,
               Amount = i.Amount,
               IsActive = i.IsActive,
               CompanyId= i.Company.CompanyId,
               CustomerId = i.Customer.Id,
               Customer =_mapper.Map<Customer>( new CustomerUpdate
               {
                   Id = i.Customer.Id,
                   CustomerName = i.Customer.CustomerName,
                   CustomerEmail = i.Customer.CustomerEmail,
                   CustomerPhone = i.Customer.CustomerPhone
                   
               }),
               Company =_mapper.Map<Company>( new CompanyDtoUpdate
               {
                   CompanyId = i.Company.CompanyId,
                   Name = i.Company.Name,
                   Address = i.Company.Address,
                   IsActive = i.Company.IsActive
               })
           })
           .Where(x=>x.IsActive.Equals(true))
           .ToListAsync();
            return Ok(invoices);
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
          if (_context.Invoices == null)
          {
              return NotFound();
          }
            var invoice = await _context.Invoices
           .Include(i => i.Customer)
           .Include(i => i.Company)
           .Select(i => new Invoice
           {
               InvoiceId = i.InvoiceId,
               InvoiceDate = i.InvoiceDate,
               Amount = i.Amount,
               IsActive = i.IsActive,
               CompanyId = i.Company.CompanyId,
               CustomerId = i.Customer.Id,
               Customer = _mapper.Map<Customer>(new CustomerUpdate
               {
                   Id = i.Customer.Id,
                   CustomerName = i.Customer.CustomerName,
                   CustomerEmail = i.Customer.CustomerEmail,
                   CustomerPhone = i.Customer.CustomerPhone

               }),
               Company = _mapper.Map<Company>(new CompanyDtoUpdate
               {
                   CompanyId = i.Company.CompanyId,
                   Name = i.Company.Name,
                   Address = i.Company.Address,
                   IsActive = i.Company.IsActive
               })
           }).Where(x=>x.IsActive.Equals(true) && x.InvoiceId.Equals(id)).FirstAsync();

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, InvoiceUpdate invoiceUpdate)
        {
            var invoice=_mapper.Map<Invoice>(invoiceUpdate);
            if (id != invoice.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(InvoiceDto invoiceDto)
        {
            var invoice=_mapper.Map<Invoice>(invoiceDto);
          if (_context.Invoices == null)
          {
              return Problem("Entity set 'DataContext.Invoices'  is null.");
          }
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.InvoiceId }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            if (_context.Invoices == null)
            {
                return NotFound();
            }
            var invoice = await _context.Invoices.Where(x => x.IsActive.Equals(true) && x.InvoiceId.Equals(id)).FirstAsync();
            if (invoice == null)
            {
                return NotFound();
            }

            /*_context.Invoices.Remove(invoice);*/
            invoice.IsActive= false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceExists(int id)
        {
            return (_context.Invoices?.Any(e => e.InvoiceId == id)).GetValueOrDefault();
        }
    }
}
