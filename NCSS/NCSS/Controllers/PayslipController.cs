using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCSS.Controllers
{
    public class PayslipController : Controller
    {
        //
        // GET: /Payslip/
        [Authorize(Roles = "ADMIN,MOD,STAFF")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
