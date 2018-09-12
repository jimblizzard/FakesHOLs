// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OrderController.cs">
//   Copyright Microsoft Corporation. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
// <summary>
//   The OrderController
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ALMRangers.FakesGuide.MainWeb.Models;

namespace Microsoft.ALMRangers.FakesGuide.MainWeb.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        private IOrderRepository repository;

        public OrderController() : this(new OrderRepository())
        {
        }

        public OrderController(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult OrderLines(int id)
        {
            // locate the order by ID via repository
            var order = this.repository.Find(id);

            // get the corresponding orderlines
            var orderLines = this.repository.OrderLines(order.Id);

            // initialize the calculation values
            double total = 0d;
            double taxRate = order.TaxRate / 100;
            double taxMultiplier = 1 + taxRate;

            // run through the list and just summarize conditionally if taxable or not
            foreach (var lineItem in orderLines)
            {
                if (lineItem.IsTaxable)
                {
                    total += lineItem.Quantity * lineItem.UnitCost * taxMultiplier;
                }
                else
                {
                    total += lineItem.Quantity * lineItem.UnitCost;
                }
            }

            // make the view model and set its properties
            var viewModel = new OrderSummaryViewModel();
            viewModel.Order = order;
            viewModel.OrderLines = orderLines.ToList();
            viewModel.Total = total;

            return this.View(viewModel);

        }
    }
}