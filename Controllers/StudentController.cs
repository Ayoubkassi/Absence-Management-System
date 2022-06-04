// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;
// using Absence.Models;
// using Absence.Data;
// using Microsoft.AspNetCore.Http;
// using Newtonsoft.Json;
//
// namespace Absence.Controllers
// {
//   public class StudentController : Controller
// 	{
// 		private readonly ApplicationDbContext _db;
//
// 		public StudentController(ApplicationDbContext db)
// 		{
// 				_db = db;
// 		}
//
//     //GET - EDIT
//     public IActionResult Edit(int? id)
//     {
//         if(id==null || id == 0)
//         {
//             return NotFound();
//         }
//         var obj = _db.User.Find(id);
//         if (obj == null)
//         {
//             return NotFound();
//         }
//
//         return View(obj);
//     }
//
//     //POST - EDIT
//     [HttpPost]
//     [ValidateAntiForgeryToken]
//     public IActionResult Edit(User obj)
//     {
//         if (ModelState.IsValid)
//         {
//             _db.User.Update(obj);
//             _db.SaveChanges();
//             return RedirectToAction("Index");
//         }
//         return View(obj);
//
//     }
//
// }
