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
  public class ProfController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ProfController(ApplicationDbContext db)
		{
				_db = db;
		}

    //Get Login category page
		public IActionResult Welcome()
		{
      var prof = JsonConvert.DeserializeObject<Prof>(HttpContext.Session.GetString("loginSession"));
			return View(prof);
		}

    //Get Prof Dash
		public IActionResult ProfDash()
		{
			var prof = JsonConvert.DeserializeObject<Prof>(HttpContext.Session.GetString("loginSession"));
			return View(prof);
		}



}

}
