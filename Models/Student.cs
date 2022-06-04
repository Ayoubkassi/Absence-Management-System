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


        public virtual User User { get; set; }

        public List<Abse> Absences { get; set; }

    }
}
