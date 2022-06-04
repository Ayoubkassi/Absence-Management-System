using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Absence.Models;
using Absence.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Absence.Controllers
{
  public class StudentController : Controller
	{
		private readonly ApplicationDbContext _db;

		public StudentController(ApplicationDbContext db)
		{
				_db = db;
		}

    //Get Login category page
		public IActionResult Welcome()
		{
      var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
			return View(student);
		}

    //Get Student Dash
		public IActionResult StudentDash()
		{
			var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
			return View(student);
		}

    //Get Register category page
		public IActionResult CompteConsultation()
		{
			var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
			return View(student);
		}



}

}
