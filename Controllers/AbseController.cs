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
  public class AbseController : Controller
	{
		private readonly ApplicationDbContext _db;

		public AbseController(ApplicationDbContext db)
		{
				_db = db;
		}

   


		public string getStudentName(int id)
		{
			var obj = _db.Students.Find(id);
			string name = obj.UserName;
			return name;
		}


}

}
