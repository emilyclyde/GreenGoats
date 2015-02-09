using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenGoats.Controllers
{
    public class SaleController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
          ViewBag.MyMessageToUsers = "Hello from Green Grazing Goats!!! This year we are expanding our herd. We have little baby goats! If you would like to purchase a new baby this year please contact us";
          return View();
        }
    }
}