using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_API.Model.Dto
{
    public class CustomerDto
    {
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string CustomerCity { get; set; } = string.Empty;
        public string CustomerSex { get; set; } = string.Empty;

        public string IdentityCardNumber = string.Empty;

        public DateTime IDCardMadeDate = DateTime.Now;
        public int CompanyId { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
