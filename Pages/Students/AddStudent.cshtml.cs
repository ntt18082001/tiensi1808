using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;

namespace WebApp.Pages.Students
{
    public class AddStudentModel : PageModel
    {
        public void OnGet()
        {
			SchoolDbContext db = new();
			ViewData["data"] = db.Classes.ToList();
        }
		public IActionResult OnPost(Student student)
		{
			SchoolDbContext db = new();
			db.Students.Add(student);
			db.SaveChanges();
			return Redirect("/Students/GetAll");
		}
    }
}
