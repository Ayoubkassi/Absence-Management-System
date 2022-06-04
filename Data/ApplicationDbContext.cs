using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Absence.Models;

namespace Absence.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> User { get; set; }
    public DbSet<Student> Students {get; set;}
    public DbSet<Abse> Absences {get; set;}

  }
}
