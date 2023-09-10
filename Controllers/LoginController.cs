using AspMvcEF.Models;
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
                //Hacer busqueda en BD con EF
                using (PRACTICAMVCEntities db = new PRACTICAMVCEntities())
                {
                    var lst = from i in db.USERS
                              where i.USERNAME == user && i.PASSWORD == pass && i.IDSTATE == 1
                              select i;
                    if (lst.Count() > 0)
                    {
                        //variable de sesion | Obj
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido");
                    }
                }
            }
            catch (Exception ex)
            {
                //COntent regresa un strin en vez de vista
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}