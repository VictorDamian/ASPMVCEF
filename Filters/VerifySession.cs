using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvcEF.Controllers;
using AspMvcEF.Models;

namespace AspMvcEF.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        //override clase padre | filtro entra antes del controller
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Obtener la sesion | evalua la sesion
            var objUser = (USERS)HttpContext.Current.Session["User"];
            //si es null no pasa el filtro
            if (objUser == null)
            {
                //si el controller es diferente a Login
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Index");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}