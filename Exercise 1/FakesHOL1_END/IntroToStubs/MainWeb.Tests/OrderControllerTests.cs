using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.ALMRangers.FakesGuide.MainWeb.Controllers;
using Microsoft.ALMRangers.FakesGuide.MainWeb.Models;
using ModelFakes = Microsoft.ALMRangers.FakesGuide.MainWeb.Models.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MainWeb.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void OrderController_orderSummaryTotalCheck_equalsSum()
        {
            // arrange
            const int TestOrderId = 10;

            IOrderRepository repository = new ModelFakes.StubIOrderRepository()
            {
                FindInt32 = id =>
                {
                    Order testOrder = new Order
                    {
                        Id = 1,
                        CustomerName = "jones",
                        TaxRate = 5
                    };

                    return testOrder;
                },

                OrderLinesInt32 = id =>
                {
                    var OrderLines = GetOrderLines();

                    return OrderLines.AsQueryable();
                }
            };

            var controller = new OrderController(repository);

            // act
            var result = controller.OrderLines(TestOrderId) as ViewResult;
            var data = result.Model as OrderSummaryViewModel;

            // assert
            Assert.AreEqual(5675, data.Total, "Order summary total not correct");
        }

        private static IQueryable<OrderLines> GetOrderLines()
        {
            var orderLines = new List<OrderLines>
                        {
                            new OrderLines { Id = 10, IsTaxable = true, ProductName = "widget1", Quantity = 10, UnitCost = 10 },
                            new OrderLines { Id = 10, IsTaxable = false, ProductName = "widget2", Quantity = 20, UnitCost = 20 },
                            new OrderLines { Id = 10, IsTaxable = true, ProductName = "widget3", Quantity = 30, UnitCost = 30 },
                            new OrderLines { Id = 10, IsTaxable = false, ProductName = "widget4", Quantity = 40, UnitCost = 40 },
                            new OrderLines { Id = 10, IsTaxable = true, ProductName = "widget5", Quantity = 50, UnitCost = 50 },
                        };
            return orderLines.AsQueryable();
        }
    }
}
