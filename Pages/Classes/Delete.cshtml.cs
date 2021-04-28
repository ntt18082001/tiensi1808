using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Database;

namespace WebApp.Pages.Classes
{
    public class DeleteModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
			SchoolDbContext db = new();
			var del = db.Classes
				.Include(x => x.Students)
				.SingleOrDefault(x => x.Id == id);
			foreach (Student item in del.Students)
			{
				db.Students.Remove(item);
			}
			db.Classes.Remove(del);
			db.SaveChanges(); 
			return Redirect("/Classes/GetAll");
        }
    }
}
