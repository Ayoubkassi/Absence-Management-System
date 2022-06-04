using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Absence.Models
{
    public class Admin
    {
        [Key]
        public virtual int IdAdmin { get; set; }

        public virtual User User { get; set; }



    }
}
