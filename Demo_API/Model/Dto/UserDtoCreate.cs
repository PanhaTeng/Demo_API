using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Demo_API.Model.Dto
{
    public class UserDtoCreate
    {
       
       
        public string Email { get; set; }
      
        public string FirstName { get; set; }
       
        public string LastName { get; set;}
       
        public string Password { get; set;}
    }
}
