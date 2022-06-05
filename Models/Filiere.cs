using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Absence.Models
{
    public class Filiere
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        public string Abreviation { get; set; }


        [Required]
        public string Niveau { get; set; }

        [Required]
        public string NomFiliere { get; set; }




    }
}
