using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_API.Model
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Address { get; set; } = string.Empty;
        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Customer>? Customers { get; set; }
        [Column(TypeName = "bit")]
        public bool? IsActive { get; set; } = true;
    }
}
