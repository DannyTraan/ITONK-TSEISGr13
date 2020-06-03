using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockTransactionItems.Models
{
    public class Stock
    {
        public Stock() { }

        [Key]
        public int StockId { get; set; }
        public int OwnerId { get; set; }
        public string StockName { get; set; }
        public double StockPrice { get; set; }
        public int StockCount { get; set; }
    }
}
