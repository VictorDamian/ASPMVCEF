using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMvcEF.Models.TableViewModel
{
    public class EmployeeTableViewModel
    {
        //una clase que sirve para mostrar los datos que necesitas
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Edad { get; set; }
        public string Pos { get; set; }
    }
}