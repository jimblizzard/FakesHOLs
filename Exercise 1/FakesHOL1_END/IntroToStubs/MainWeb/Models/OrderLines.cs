using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.ALMRangers.FakesGuide.MainWeb.Models
{
    public class OrderLines
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public double UnitCost { get; set; }

        public bool IsTaxable { get; set; }

        public int Quantity { get; set; }
    }
}