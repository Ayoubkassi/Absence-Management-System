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

	public class UserController : Controller
	{
		private readonly ApplicationDbContext _db;

		public UserController(ApplicationDbContext db)
		{
				_db = db;
		}


		//Get Register category page
		// public IActionResult CompteConsultation()
		// {
		// 	var usr = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("loginSession"));
		// 	return View(usr);
		// }

		//Get Register category page
		public IActionResult Register()
		{
			return View();
		}


		public IActionResult Logout()
		{
			//remove session
			HttpContext.Session.Clear();
			return RedirectToAction("Login","User");
		}


		//Get Admin Dash
		// public IActionResult AdminDash()
		// {
		//
		// 	//to get session we use
		// 	var usr = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("loginSession"));
		// 	return View(usr);
		// }

		//Get Prof Dash
		// public IActionResult ProfDash()
		// {
		// 	var usr = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("loginSession"));
		// 	return View(usr);
		// }

		//Get Student Dash
		// public IActionResult StudentDash()
		// {
		// 	var usr = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("loginSession"));
		// 	return View(usr);
		// }

		//Get Login category page
		public IActionResult Login()
		{
			return View();
		}

		// //Get Login category page
		// public IActionResult Welcome(string username)
		// {
		// 	ViewData["Username"]= username;
		// 	IEnumerable<User> users = _db.User;
		//
		// 	User obj = null;
		// 	foreach(User user in users){
		// 		if(user.UserName == username){
		// 			obj = user;
		// 		}
		// 	}
		//
		// 	return View();
		// }

		//POST - CREATE
		[HttpPost]
	  [ValidateAntiForgeryToken]
		public IActionResult Register(Student obj)
		{
					 if (ModelState.IsValid)
					 {
					 		//just for temp user accounts
					 		//obj.Role="Student";
							 _db.Students.Add(obj);
							 // _db.Profs.Add(obj);
							 // _db.Admins.Add(obj);
							 _db.SaveChanges();
							 return RedirectToAction("Login","User");
					 }
					 return View(obj);

		}







		[HttpPost]
	  	[ValidateAntiForgeryToken]
		public IActionResult Login(string UserName , string Password)
		{
					//verification part
					if(UserName == "" && Password == ""){
						Console.WriteLine("Enter Valid values");
					}else{
							//first students
						 IEnumerable<Student> students = _db.Students;
						 IEnumerable<Prof> profs = _db.Profs;
						 IEnumerable<Admin> admins = _db.Admins;


						 foreach(Student student in students){
						 	if(student.UserName == UserName && student.Password == Password){
						 		//add session
						 		//set the value of the session into this key
						 		HttpContext.Session.SetString("loginSession",JsonConvert.SerializeObject(student));
						 		return RedirectToAction("Welcome", "Student");
						 	}
						 }

						 //second Profs
						 foreach(Prof prof in profs){
						 	if(prof.UserName == UserName && prof.Password == Password){
						 		//add session
						 		//set the value of the session into this key
						 		HttpContext.Session.SetString("loginSession",JsonConvert.SerializeObject(prof));
						 		return RedirectToAction("Welcome", "Prof");
						 	}
						 }


						 foreach(Admin admin in admins){
						 	if(admin.UserName == UserName && admin.Password == Password){
						 		//add session
						 		//set the value of the session into this key
						 		HttpContext.Session.SetString("loginSession",JsonConvert.SerializeObject(admin));
						 		return RedirectToAction("Welcome", "Admin");
						 	}
						 }



					}

					return View();


		}






	}

}
