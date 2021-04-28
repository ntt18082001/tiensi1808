using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Classes
{
    public class UpdateModel : PageModel
    {
        public void OnGet(int id)
        {
			SchoolDbContext db = new();
			ViewData["data"] = db.Classes
				.Include(x => x.School)
				.SingleOrDefault(x => x.Id == id);
			ViewData["dataSchool"] = db.Schools.ToList();
		}
		public IActionResult OnPost(Class lop)
		{
			SchoolDbContext db = new();
			db.Classes.Update(lop);
			db.SaveChanges();
			return Redirect("/Classes/GetAll");
		}
	}
}
