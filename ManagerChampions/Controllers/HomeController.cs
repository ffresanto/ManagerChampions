using ManagerChampions.Models;
using ManagerChampions.Models.Home;
using ManagerChampions.Services;
using ManagerChampions.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerChampions.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}