using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TobinTaxerService.Models
{
    public class TobinTaxerServiceModel
    {
        [Key]
        public int TaxerId { get; set; }
        public double Amount { get; set; }
        public double TaxAmount { get; set; }
    }
}
