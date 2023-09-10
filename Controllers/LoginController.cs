using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcEF.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string user, string pass)
        {
            try
            {
                return Content("1");
            }
            catch (Exception ex)
            {
                //COntent regresa un strin en vez de vista
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}