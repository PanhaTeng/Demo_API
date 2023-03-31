using Microsoft.AspNetCore.Identity;


namespace Demo_API.Model
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; }=String.Empty;
        
    }
}
