using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;

namespace WebApp.Pages.Classes
{
    public class AddClassModel : PageModel
    {
        public void OnGet()
        {
			SchoolDbContext db = new();
			ViewData["data"] = db.Schools.ToList();
        }
		public IActionResult OnPost(Class lop)
		{
			SchoolDbContext db = new();
			db.Classes.Add(lop);
			db.SaveChanges();
			return Redirect("/Classes/GetAll");
		}
    }
}
