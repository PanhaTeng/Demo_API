using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_API.Model.Dto
{
    public class CustomerDtoGet:CustomerUpdate
    {
        public CompanyDtoUpdate? Company { get; set; }
        public ICollection<InvoiceUpdate>? Invoices { get; set; }

    }
}
