using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.ALMRangers.FakesGuide.MainWeb.Models
{
    public class OrderRepository : IOrderRepository
    {
        public IQueryable<Order> All
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<OrderLines> OrderLines(int id)
        {
            throw new NotImplementedException();
        }

        public Order Find(int id)
        {
            throw new NotImplementedException();
        }

    }
}