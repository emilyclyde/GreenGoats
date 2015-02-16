using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenGoats.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Learn About Goats Here! Please see our book page about some great titles!!!  ";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Please contact us for more information about Green Goats!";

      return View();
    }

  }
}