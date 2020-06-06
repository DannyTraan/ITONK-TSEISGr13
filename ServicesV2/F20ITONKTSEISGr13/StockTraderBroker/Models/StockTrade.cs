using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Models
{
    public class StockTrade
    {
        [Key]
        public int StockTransactionId { get; set; }
        public int StockId { get; set; }
        public double StockPrice { get; set; }
        public DateTime DatePurchased { get; set; }
    }
}
