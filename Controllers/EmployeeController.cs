using AspMvcEF.Models;
using AspMvcEF.Models.TableViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcEF.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<EmployeeViewModel> lts = null;
            using (PRACTICAMVCEntities db = new PRACTICAMVCEntities())
            {
                lts = db.EMPLOYEE.Where(x => x.POSITION == "Contador").Select(x=> new EmployeeViewModel
                {
                    Id = x.IDEMP,
                    Name = x.NAME,
                    Edad = x.AGE
                }).ToList();
                return View(lts);
            }
        }
    }
}