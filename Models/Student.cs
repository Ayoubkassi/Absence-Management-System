using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Absence.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }


        [Required]
        public string UserName { get; set; }

        //[Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int ListeId { get; set; } = 0;

        
        public List<Abse> Absences { get; set; }



    }
}
