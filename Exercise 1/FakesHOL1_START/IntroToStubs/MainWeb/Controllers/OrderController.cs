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
            return this.View();
        }
    }
}