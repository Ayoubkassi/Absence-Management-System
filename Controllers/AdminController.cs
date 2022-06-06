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
using ClosedXML.Excel;
using System.IO;
using System.Data;
using System.Text;
using GemBox.Spreadsheet;

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

		public IActionResult ListeAbsenceFiliere()
		{
			IEnumerable<Abse> absences = _db.Absences;
    	    return View(absences);
		}

		public string getStudentName(int id)
		{
			var obj = _db.Students.Find(id);
			return obj.UserName;
		}

		public string getFiliere(int id)
		{
			var obj = _db.Students.Find(id);
			List<string> listeValues = new List<string>(new string[] { "No Filiere" , "Genie Electrique", "Reseau et systeme", "Genie Informatique" });
			return listeValues[obj.ListeId];

		}


            public IActionResult AjouterAbsence()
                    {
                            //IEnumerable<Student> students = _db.Students;
                            return View();
                    }


                    [HttpPost]
                [ValidateAntiForgeryToken]
                public IActionResult AddAbsence(Abse obj)
                {
                        if (ModelState.IsValid)
                        {
                            _db.Absences.Add(obj);
                            _db.SaveChanges();
                            return RedirectToAction("AdminDash");
                        }
                        return View(obj);

                }
		public IActionResult DeleteAbsence()
    {
    	IEnumerable<Abse> absences = _db.Absences;
    	return View(absences);
    }

    public IActionResult CreateNewAccount()
    {
    	return View();
    }

    public IActionResult AddAdmin()
    {
    	return View();
    }

    public IActionResult AddProf()
    {
    	return View();
    }

    public IActionResult AddStudent()
    {
    	return View();
    }

    [HttpPost]
	  [ValidateAntiForgeryToken]
		public IActionResult AddStudent(Student obj)
		{
					 if (ModelState.IsValid)
					 {
					 		//just for temp user accounts
					 		//obj.Role="Student";
							 _db.Students.Add(obj);
							 // _db.Profs.Add(obj);
							 // _db.Admins.Add(obj);
							 _db.SaveChanges();
							 return RedirectToAction("AdminDash");
					 }
					 return View(obj);

		}


		[HttpPost]
	  [ValidateAntiForgeryToken]
		public IActionResult AddProf(Prof obj)
		{
					 if (ModelState.IsValid)
					 {
					 		//just for temp user accounts
					 		//obj.Role="Student";
							 //_db.Students.Add(obj);
							  _db.Profs.Add(obj);
							 // _db.Admins.Add(obj);
							 _db.SaveChanges();
							 return RedirectToAction("AdminDash");
					 }
					 return View(obj);

		}


		[HttpPost]
	  [ValidateAntiForgeryToken]
		public IActionResult AddAdmin(Admin obj)
		{
					 if (ModelState.IsValid)
					 {
					 		//just for temp user accounts
					 		//obj.Role="Student";
							 //_db.Students.Add(obj);
							 // _db.Profs.Add(obj);
							  _db.Admins.Add(obj);
							 _db.SaveChanges();
							 return RedirectToAction("AdminDash");
					 }
					 return View(obj);

		}

		//GET - EDIT
        public IActionResult Edit()
        {
            
            var admin = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("loginSession"));
            return View(admin);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Admin obj)
        {
            if (ModelState.IsValid)
            {
            		Console.WriteLine(obj);
                _db.Admins.Update(obj);
                _db.SaveChanges();
                //update session infos
                HttpContext.Session.SetString("loginSession",JsonConvert.SerializeObject(obj));
                return RedirectToAction("CompteConsultation");
            }
            return View(obj);

        }

    public IActionResult CompteConsultation()
		{
			var admin = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("loginSession"));
			return View(admin);
		}


		public IActionResult ExportAbsences()
    {
    	return View();
    }

    public IActionResult ExcelExport()
    {
    	using (var workbook = new XLWorkbook())
    {
        var worksheet = workbook.Worksheets.Add("Absences");
        var currentRow = 1;
        worksheet.Cell(currentRow, 1).Value = "Name";
        worksheet.Cell(currentRow, 2).Value = "Date";
        worksheet.Cell(currentRow, 3).Value = "StudentId";

       	IEnumerable<Abse> absences = _db.Absences;


        foreach (var abs in absences)
        {
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = abs.Name;
            worksheet.Cell(currentRow, 2).Value = abs.Date;
            worksheet.Cell(currentRow, 3).Value = abs.StudentId;


        }

        using (var stream = new MemoryStream())
        {
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "absences.xlsx");
        }
    }
    }



    public IActionResult EditeAbsence()
    {
    	IEnumerable<Abse> absences = _db.Absences;
    	return View(absences);	
    }

    public IActionResult EditA(int? id)
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
    public IActionResult EditAb(Abse obj)
    {
            if (ModelState.IsValid)
            {
                _db.Absences.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("GetAbsences");
            }
             return RedirectToAction("GetAbsences");
            

    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteAb(int? id)
    {
            var obj = _db.Absences.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Absences.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("GetAbsences");
            

    }

    public IActionResult DeleteA(int? id)
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
    

    public IActionResult GetAbsences()
    {
    	IEnumerable<Abse> absences = _db.Absences;
    	return View(absences);
    }	

    public IActionResult AddStudentListe()
		{
			IEnumerable<Student> students = _db.Students;
			return View(students);
		}

		public IActionResult AddToListe(int ?id)
		{
			 if (id == null || id == 0)
            {
                return NotFound();
            }
            //Console.WriteLine("Enter edit");
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
		}

		[HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddToListe(Student obj)
    {
    	if (ModelState.IsValid)
            {
            			Console.WriteLine(obj);
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("AddStudentListe");
            }
            Console.WriteLine("Invalid");
             Console.WriteLine(obj.Email);
             Console.WriteLine(obj.ListeId);
             Console.WriteLine(obj.UserName);
             Console.WriteLine(obj.Password);

             return RedirectToAction("AdminDash");

    }

    public IActionResult ImportListeStudent()
    {
    	return View();
    }

    [HttpPost]
    public async Task<IActionResult> ImportListeStudent (List<IFormFile> files)
    {
    	var size = files.Sum(f => f.Length);

    	var filePaths = new List<string>();
    	foreach(var formFile in files)
    	{
    		if(formFile.Length > 0)
    		{
    			var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
    			filePaths.Add(filePath);

    			using(var stream = new FileStream(filePath , FileMode.Create))
    			{
    					await formFile.CopyToAsync(stream);
    			}
    		}
    	}

    	//change in db remove and add new labels
    	List<string> listeValues = new List<string>(new string[] { "No Filiere", "Genie Electrique", "Reseau et systeme" , "Genie Informatique" });
    	SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
    	var workbook = ExcelFile.Load(filePaths[0]);

    	var sb = new StringBuilder();

        // Iterate through all worksheets in an Excel workbook.
        foreach (var worksheet in workbook.Worksheets)
        {
            sb.AppendLine();
            sb.AppendFormat("{0} {1} {0}", new string('-', 25), worksheet.Name);

            // Iterate through all rows in an Excel worksheet.
            int k = 0;
            int h =0;

            foreach (var row in worksheet.Rows)
            {

                sb.AppendLine();


                int j = -1;
                // Iterate through all allocated cells in an Excel row.
                foreach (var cell in row.AllocatedCells)
                		{
                			j++;
	                    if (cell.ValueType != CellValueType.Null)
	                    {
	                        sb.Append(string.Format("{0} [{1}]", cell.Value, cell.ValueType).PadRight(25));
	                    		//Console.WriteLine(cell.Value);
	                    		//here i have the value i must just get the id
	                    		if(j == 0){ 
	                    		foreach(string s in listeValues)
	                    		{
	                    			if(s == cell.Value.ToString() && j==0)
	                    			{
	                    				//Console.WriteLine("H ="+h);
	                    				break;
	                    			}
	                    			h++;
	                    		}
	                    	}

	                    		Console.WriteLine("J = "+j);
	                    		//we got the id now we must just
	                    		if(j != 0 && (h != 0 && h < listeValues.Count) ){
	                    				//Console.WriteLine("ldakhel : "+j);
       												IEnumerable<Student> students = _db.Students;
       												foreach(Student std in students)
       												{
       													//Console.WriteLine(std.Email + " -> " + cell.Value);
       													if(std.Email == cell.Value.ToString())
       													{
       														//Console.WriteLine("l9iiito");
                                                            Console.WriteLine("Before");
                                                            Console.WriteLine(std.UserName);
                                                            Console.WriteLine(std.ListeId);
       														std.ListeId = ++h;
                                                            Console.WriteLine("h =" + h);
       														//create new one with same properties remove and add
       														_db.Students.Update(std);
                                                            Console.WriteLine(std.UserName);
                                                            Console.WriteLine(std.ListeId);
                                                            Console.WriteLine("After");

       													}
       												}
	                    		}
	                    }
	                    else
	                        sb.Append(new string(' ', 25));
                    }



                k++;
            }
        }

        //Console.WriteLine(sb.ToString());
        _db.SaveChanges();



    	return RedirectToAction("AdminDash");

    }

    


     public IActionResult ExcelStudents()
    {
    	return View();
    }

    public IActionResult ExcelExportStudents()
    {
    	using (var workbook = new XLWorkbook())
    {
        var worksheet = workbook.Worksheets.Add("ListeStudents");
        var currentRow = 1;
        //get number of total ids
        //and then iterate to craete liste of them and asign each one to new string

        List<int> listIds = new List<int>(); 
       	IEnumerable<Student> students = _db.Students;
       	foreach(Student std in students)
       	{
       		//verify doesn't exist
       		bool exist = false;
       		foreach(int i in listIds){
       			if(std.ListeId == i){
       				exist = true;
       			}
       		}
       		if(exist == false){
       			listIds.Add(std.ListeId);
       		}

       	}


       	List<string> listeValues = new List<string>(new string[] { "No Filiere" , "Genie Electrique", "Reseau et systeme", "Genie Informatique" });

       	foreach(int i in listIds)
       	{
       		  int k = 0;

        		worksheet.Cell(currentRow, ++k).Value = listeValues[i];
        		//add all cellus
        		foreach(Student std in students)
        		{
        			if(std.ListeId == i)
        			{
        				worksheet.Cell(currentRow, ++k).Value = std.Email;
        			}
        		}

        		currentRow++;
       	}




       /* foreach (Student std in students)
        {
            currentRow++;
            worksheet.Cell(currentRow, std.ListeId).Value = std.UserName;

        }
*/
        using (var stream = new MemoryStream())
        {
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "studentsListe.xlsx");
        }
    }
    }


    public IActionResult JustifierAbsence()
    {
    	IEnumerable<Abse> absences = _db.Absences;
    	return View(absences);
    }

    public IActionResult JustifierA(int? id)
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
                return RedirectToAction("GetAbsences");
            }
             return RedirectToAction("GetAbsences");
            

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

    public IActionResult JustifierDocuments()
    {
    	IEnumerable<Abse> absences = _db.Absences;
    	return View(absences);	
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult JustifierDocumente(Abse obj)
    {
    	if (ModelState.IsValid)
            {
            			obj.IsJustified = 1;
                _db.Absences.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("GetAbsences");
            }
             return RedirectToAction("GetAbsences");

    }

    public IActionResult AddNotice()
    {
    	IEnumerable<Abse> absences = _db.Absences;
    	return View(absences);	
    }

    public IActionResult NoticeAdd(int? id)
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
    public IActionResult NoticeAb(Abse obj)
    {
    	if (ModelState.IsValid)
            {
            			//obj.IsJustified = 1;
                _db.Absences.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("GetAbsences");
            }
             return RedirectToAction("GetAbsences");

    }


    public IActionResult AddFiliere()
    {
    	return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddFiliere(Filiere obj)
    {
            if (ModelState.IsValid)
            {
                _db.Filieres.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("AdminDash");
            }
            return View(obj);

    }




}

}
