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
    public class CompaniesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CompaniesController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<CompanyDtoGet>>>> GetCompanies()
        {
            if (_context.Companies == null)
            {
              return NotFound();
            }
            var companies = await _context.Companies
                                    .Include(c => c.Invoices)
                                    .Include(c => c.Customers)
                                    .Select(c=> new CompanyDtoGet
                                    {
                                       CompanyId=c.CompanyId,
                                       Address = c.Address,
                                       Name = c.Name,
                                       IsActive = c.IsActive,
                                       Customers =_mapper.Map<List<CustomerUpdate>>(c.Customers),
                                       Invoices = _mapper.Map<List<InvoiceUpdate>>(c.Invoices)
                                        
                                    })
                                    .Where(x => x.IsActive.Equals(true))
                                    .ToListAsync();

            var response = new BaseResponse<IEnumerable<CompanyDtoGet>>
            {
                Data = companies,
                StatusCode = 200,
                Message = "Success"
            };
            return Ok(response);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CompanyDtoGet>>> GetCompany(int id)
        {
          if (_context.Companies == null)
          {
              return NotFound();
          }
            var company = await _context.Companies
                                    .Include(c => c.Invoices)
                                    .Include(c => c.Customers)
                                    .Select(c => new CompanyDtoGet
                                    {
                                        CompanyId = c.CompanyId,
                                        Address = c.Address,
                                        Name = c.Name,
                                        IsActive = c.IsActive,
                                        Customers = _mapper.Map<List<CustomerUpdate>>(c.Customers),
                                        Invoices = _mapper.Map<List<InvoiceUpdate>>(c.Invoices)

                                    }).Where(x=>x.IsActive.Equals(true) && x.CompanyId.Equals(id)).FirstAsync();

            if (company == null)
            {

                throw new Exception("Company is null");
                return NotFound();

            }
            var response = new BaseResponse<CompanyDtoGet>
            {
                Data = company,
                StatusCode = 200,
                Message = "Success"
            };
            return Ok(response);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, CompanyDtoUpdate companyDtoUpdate)
        {
            var company = _mapper.Map<Company>(companyDtoUpdate);
            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            /*var response = new BaseResponse<CompanyDtoGet>
            {
                Data =_mapper.Map<CompanyDtoGet>(company) , StatusCode = 200,Message="204"
            };*/
            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CompanyDtoCreate companyCreate)
        {
            var company= _mapper.Map<Company>(companyCreate);
          if (_context.Companies == null)
          {
              return Problem("Entity set 'DataContext.Companies'  is null.");
          }
            _context.Companies.Add(_mapper.Map<Company>(company));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (_context.Companies == null)
            {
                return NotFound();
            }
            var company = await _context.Companies.Where(x => x.IsActive == true && x.CompanyId == id).FirstAsync();
            if (company == null)
            {
                return NotFound();
            }
            company.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
