using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Schools
{
    public class DeleteModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
			SchoolDbContext db = new();
			var del = db.Schools
				.Include(x => x.Classes)
				.ThenInclude(x => x.Students)
				.SingleOrDefault(x => x.Id == id);
			foreach (var item in del.Classes)
			{
				foreach(var item2 in item.Students)
				{
					db.Students.Remove(item2);
				}
				db.Classes.Remove(item);
			}
			db.Schools.Remove(del);
			db.SaveChanges();
			return Redirect("/Schools/GetAll");
        }
    }
}
