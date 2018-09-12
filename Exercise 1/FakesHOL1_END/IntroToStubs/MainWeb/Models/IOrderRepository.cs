using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.ALMRangers.FakesGuide.MainWeb.Models
{
    using System.Linq;

    public interface IOrderRepository
    {
        IQueryable<Order> All { get; }

        IQueryable<OrderLines> OrderLines(int id);

        Order Find(int id);
    }
}