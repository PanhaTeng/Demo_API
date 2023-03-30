using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_API.Model.Dto
{
    public class CompanyDtoCreate
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public bool? IsActive { get; set; } = true;
    }
}
