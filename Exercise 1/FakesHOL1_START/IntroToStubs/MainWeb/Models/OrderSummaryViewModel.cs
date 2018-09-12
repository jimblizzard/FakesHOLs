using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.ALMRangers.FakesGuide.MainWeb.Models
{
    public class OrderSummaryViewModel
    {
        public Order Order { get; set; }

        public List<OrderLines> OrderLines { get; set; }

        public double Total { get; set; }
    }

}
