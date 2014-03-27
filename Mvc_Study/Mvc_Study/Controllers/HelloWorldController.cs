using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        //public String Index()
        //{
        //    //return View();
        //    return "This is default action";
        //}

        //public string Welcome(string name, int numTimes = 1)//Query String Reading
        //{
        //    return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is: " + numTimes);
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;
           
            return View();
        }
    }
}
