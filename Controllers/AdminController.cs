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
  public class AdminController : Controller
	{
		private readonly ApplicationDbContext _db;

		public AdminController(ApplicationDbContext db)
		{
				_db = db;
		}

    //Get Login category page
		public IActionResult Welcome()
		{
      var admin = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("loginSession"));
			return View(admin);
		}

    //Get Admin Dash
		public IActionResult AdminDash()
		{
			var admin = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("loginSession"));
			return View(admin);
		}



}

}
