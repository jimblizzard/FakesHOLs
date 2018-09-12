using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.ALMRangers.FakesGuide.MainWeb.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderLines = new HashSet<OrderLines>();
        }

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public double TaxRate { get; set; }

        public ICollection<OrderLines> OrderLines { get; set; }

    }
}