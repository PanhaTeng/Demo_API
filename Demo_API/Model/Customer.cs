using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_API.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }=string.Empty;
     
        public string CustomerEmail { get; set; }=string.Empty;
        public string CustomerPhone { get; set; }=string.Empty;
        public string CustomerAddress { get; set; }=string.Empty;
        public string CustomerCity { get; set; } = string.Empty;
        public string CustomerSex { get; set; } = string.Empty;

        public string IdentityCardNumber=string.Empty;  

        public DateTime IDCardMadeDate=DateTime.Now;
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
        [Column(TypeName = "bit")]
        public bool? IsActive { get; set; } = true;
        // generate script for insert data to database 1000 row

    }
}
