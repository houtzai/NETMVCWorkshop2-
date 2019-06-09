using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NETMVCworkshop2.Controllers
{
    public class HomeController : Controller
    {
        Models.BookDataService bookData = new Models.BookDataService();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.list = this.bookData.GetBook();
            return View();
        }
    }
}