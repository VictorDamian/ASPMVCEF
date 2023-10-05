using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcEF.Controllers
{
    public class CloseController : Controller
    {
        // GET: Close
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}