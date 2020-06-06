using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockShareRequester.Models
{
    public class Requester
    {
        [Key]
        public int OwnerId { get; set; }
        public double Balance { get; set; }
    }
}
