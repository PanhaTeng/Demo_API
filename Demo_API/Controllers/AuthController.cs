using AutoMapper;
using Demo_API.Data;
using Demo_API.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Drawing.Printing;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuthController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Register(UserDtoCreate userDtoCreate)
        {
            if(userDtoCreate == null)
            {
                return BadRequest("Data provide can't be null!.");
            }
            return Ok();
        }
        public IActionResult Login(string returnUrl)
        {
            return Ok();
        }
    }
}
