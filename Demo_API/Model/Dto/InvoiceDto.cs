﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_API.Model.Dto
{
    public class InvoiceDto
    {
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } = decimal.Zero;
   /*     public Company? Company { get; set; }*/
        public int CompanyId { get; set; }
/*        public Customer? Customer { get; set; }*/
        public int CustomerId { get; set; }
        [Column(TypeName = "bit")]
        public bool? IsActive { get; set; } = true;
    }
}
