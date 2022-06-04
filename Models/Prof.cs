using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Absence.Models
{
    public class Prof
    {
        [Key]
        public virtual int IdProf { get; set; }

        public virtual User User { get; set; }


    }
}
