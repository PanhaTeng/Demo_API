using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_API.Model.Dto
{
    public class CompanyDtoGet
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public ICollection<InvoiceUpdate>? Invoices { get; set; }
        public ICollection<CustomerUpdate>? Customers { get; set; }
        [Column(TypeName = "bit")]
        public bool? IsActive { get; set; } = true;
    }
}
