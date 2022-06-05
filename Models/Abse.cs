using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Absence.Models
{
    public class Abse
    {
        [Key]
        public virtual int Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        //Navigation properties

        public int StudentId { get; set; }

        public Student Student { get; set; } 

        public int IsJustified { get; set; } = 0;

        public string LetterJustification {get ; set;}="";

        public string DocumentJustification {get; set;} ="";

        public string Notice {get ; set;}




    }
}
