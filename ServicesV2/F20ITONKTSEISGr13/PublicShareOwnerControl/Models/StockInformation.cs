using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Models
{
    public class StockInformation
    {
        [Key]
        public int StockId { get; set; }
        public int OwnerId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public double StockPrice { get; set; }
        public string StockName { get; set; }
    }
}
