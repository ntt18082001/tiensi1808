using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Database;

namespace WebApp.Pages.Students
{
    public class UpdateModel : PageModel
    {
        public void OnGet(int id)
        {
			SchoolDbContext db = new();
			ViewData["data"] = db.Students
				.Include(x => x.Class)
				.SingleOrDefault(x => x.Id == id);
			ViewData["dataClass"] = db.Classes.ToList();
        }
		public IActionResult OnPost(WebApp.Database.Student student)
		{
			SchoolDbContext db = new();
			db.Students.Update(student);
			db.SaveChanges();
			return Redirect("/Students/GetAll");
		}
    }
}
