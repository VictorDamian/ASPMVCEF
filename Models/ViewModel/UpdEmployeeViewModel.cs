using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspMvcEF.Models.ViewModel
{
    public class UpdEmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "The fiel must be only letter")]
        [StringLength(maximumLength: 80, MinimumLength = 4)]
        public string Name { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Age number must be only numbers")]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Position { get; set; }
    }
}