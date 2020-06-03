using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Models
{
    public class StockTrader
    {
        public StockTrader() { }
        
        public int UserId { get; set; }
        public int StockAmount { get; set; }
        public double StockPrice { get; set; }
        public string StockName { get; set; }
    }
}
