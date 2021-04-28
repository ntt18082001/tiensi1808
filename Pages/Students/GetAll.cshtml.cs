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
    public class GetAllModel : PageModel
    {
        public void OnGet()
        {
			SchoolDbContext db = new();
			ViewData["data"] = db.Students.Include(x => x.Class).ToList();
        }
    }
}
