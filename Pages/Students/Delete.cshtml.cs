using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;

namespace WebApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
			SchoolDbContext db = new();
			var del = db.Students.Find(id);
			db.Students.Remove(del);
			db.SaveChanges();
			return Redirect("/Students/GetAll");
        }
    }
}
