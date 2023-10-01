using AspMvcEF.Models;
using AspMvcEF.Models.TableViewModel;
using AspMvcEF.Models.ViewModel;
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
            List<EmployeeTableViewModel> lts = null;
            using (PRACTICAMVCEntities db = new PRACTICAMVCEntities())
            {
                lts = db.EMPLOYEE.Where(x => x.AGE >= 20).Select(x=> new EmployeeTableViewModel
                {
                    Id = x.IDEMP,
                    Name = x.NAME,
                    Edad = x.AGE,
                    Email = x.MAIL,
                    Pos =x.POSITION
                }).ToList();
                return View(lts);
            }
        }
        [HttpGet]
        public ActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(EmployeeViewModel model)
        {
            // Valida los dataanotations
            // si no es valido relleba el modelo
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new PRACTICAMVCEntities())
            {
                //modelo del EF
                EMPLOYEE oEmployee = new EMPLOYEE();
                oEmployee.NAME = model.Name;
                oEmployee.AGE = model.Age;
                oEmployee.MAIL = model.Email;
                oEmployee.POSITION = model.Position;

                db.EMPLOYEE.Add(oEmployee);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Employee/"));
        }
    }
}