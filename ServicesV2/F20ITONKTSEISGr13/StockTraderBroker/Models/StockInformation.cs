using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Models
{
    public class StockInformation
    {
        [Key]
        public int StockId { get; set; }
        public string StockName { get; set; }
        public double StockPrice { get; set; }
        public int OwnerId { get; set; }
        public int StockAmount { get; set; }
    }
}
