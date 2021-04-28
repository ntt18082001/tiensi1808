using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;

namespace WebApp.Pages.Schools
{
	public class InsertModel : PageModel
	{
		public void OnGet()
		{
		}
		public IActionResult OnPost(School school)
		{
			SchoolDbContext db = new();

			db.Schools.Add(school);
			db.SaveChanges();

			return Redirect("/Schools/GetAll");
		}
	}
}