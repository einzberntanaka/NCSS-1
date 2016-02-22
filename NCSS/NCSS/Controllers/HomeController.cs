using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCSS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public ActionResult Portal()
        {
            if (Request.Cookies["user"] != null && Session["user"] != null)
                return View();
            else
                return RedirectToAction("Index", "Users");
        }
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public ActionResult GetActionList()
        {
            return null;
        }

    }
}
