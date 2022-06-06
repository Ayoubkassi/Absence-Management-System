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

    //Get Login student page
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


		//get consultation
		public IActionResult CompteConsultation()
		{
			var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
			return View(student);
		}

		//GET - EDIT
        public IActionResult Edit()
        {
            
            var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
            return View(student);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                //update session infos
                HttpContext.Session.SetString("loginSession",JsonConvert.SerializeObject(obj));
                return RedirectToAction("CompteConsultation");
            }
            return View(obj);

        }

        public IActionResult JustifierLettres()
        {

        	//get session variable
        	var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
        	IEnumerable<Abse> absences = _db.Absences;
        	List<Abse> myAbsences = new List<Abse>();
        	foreach(Abse abs in absences)
        	{
        		if(abs.StudentId == student.IdStudent)
        		{
        			myAbsences.Add(abs);
        		}
        	}
    			return View(myAbsences);
        }

        public IActionResult JustifierLettre(int? id)
        {
        	if (id == null || id == 0)
            {
                return NotFound();
            }
            //Console.WriteLine("Enter edit");
            var obj = _db.Absences.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult JustifierAb(Abse obj)
    {
            if (ModelState.IsValid)
            {
            			obj.IsJustified = 1;
                _db.Absences.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("JustifierLettres");
            }
             return RedirectToAction("JustifierLettres");
            

    }



    public IActionResult JustifierDocuments()
        {

        	//get session variable
        	var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
        	IEnumerable<Abse> absences = _db.Absences;
        	List<Abse> myAbsences = new List<Abse>();
        	foreach(Abse abs in absences)
        	{
        		if(abs.StudentId == student.IdStudent)
        		{
        			myAbsences.Add(abs);
        		}
        	}
    			return View(myAbsences);
        }


        public IActionResult JustifierDocument(int? id)
        {
        	if (id == null || id == 0)
            {
                return NotFound();
            }
            //Console.WriteLine("Enter edit");
            var obj = _db.Absences.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult JustifierDocument(Abse obj)
    {
    	if (ModelState.IsValid)
            {
            			obj.IsJustified = 1;
                _db.Absences.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("StudentDash");
            }
             return RedirectToAction("StudentDash");

    }


    public IActionResult NoticeAbsence()
    {
    	return View();
    }

    public IActionResult AddNoticeAbsence(Abse abs)
    {
				var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
    		abs.StudentId = student.IdStudent;
    		abs.Notice="0";
    	 if (ModelState.IsValid)
					 {
							 _db.Absences.Add(abs);
							 _db.SaveChanges();
							 return RedirectToAction("StudentDash");
					 }
					 return View("StudentDash");
    }


    public IActionResult ConsulterAbsence()
    {
    			//get session variable
        	var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("loginSession"));
        	IEnumerable<Abse> absences = _db.Absences;
        	List<Abse> myAbsences = new List<Abse>();
        	foreach(Abse abs in absences)
        	{
        		if(abs.StudentId == student.IdStudent)
        		{
        			myAbsences.Add(abs);
        		}
        	}
    			return View(myAbsences);
    }

    public IActionResult AbsenceDetail(int? id)
    {
    	if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Absences.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
    }






}

}
