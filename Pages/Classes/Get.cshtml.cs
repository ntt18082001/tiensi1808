using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;

namespace WebApp.Pages.Classes
{
    public class GetModel : PageModel
    {
        public void OnGet(int id)
        {
			SchoolDbContext db = new();
			ViewData["data"] = db.Classes.Find(id);
        }
    }
}
