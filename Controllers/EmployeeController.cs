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
        // GET DATA
        public ActionResult Update(int id)
        {
            UpdEmployeeViewModel model = new UpdEmployeeViewModel();
            using (var db = new PRACTICAMVCEntities())
            {
                // para obtener el dato id
                var oEmployee = db.EMPLOYEE.Find(id);
                model.Id = oEmployee.IDEMP;
                model.Name = oEmployee.NAME;
                model.Age = oEmployee.AGE;
                model.Position = oEmployee.POSITION;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(UpdEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new PRACTICAMVCEntities())
            {
                //le asigna los datos a la entidad
                var oEmployee = db.EMPLOYEE.Find(model.Id);
                oEmployee.NAME = model.Name;
                oEmployee.AGE = model.Age;
                if(model.Email != null && model.Email.Trim() != "")
                {
                    oEmployee.MAIL = model.Email;
                }
                oEmployee.POSITION = model.Position;
                db.Entry(oEmployee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Employee/"));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var db = new PRACTICAMVCEntities())
            {
                var ob = db.EMPLOYEE.Find(id);
                db.Entry(ob).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return Content("1");
        }
    }
}