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

        [Required]
        public string UserName { get; set; }

        //[Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
