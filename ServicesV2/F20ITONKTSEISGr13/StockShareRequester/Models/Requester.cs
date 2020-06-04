using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockShareRequester.Models
{
    public class Requester
    {
        public bool IsRequested { get; set; }
        public int StockShareId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
    }
}
