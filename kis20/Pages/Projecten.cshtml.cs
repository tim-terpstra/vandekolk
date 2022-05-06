using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using kis20.Business;
using System.Data.SqlClient;

namespace kis20.Pages
{
    public class ProjectenModel : PageModel
    {
        private readonly ILogger<ProjectenModel> _logger;
        public List<LijstProject> projecten;
        public int err;

        public ProjectenModel(ILogger<ProjectenModel> logger)
        {
            _logger = logger;
            try
            {
                projecten = new Database().getProjectenlijst();
                
            }
            catch (SqlException)
            {
                err = -1;
                return;
            }
            err = 1;
        }

        public IActionResult OnGet()
        {
            if(err < 0) return Redirect("/503");

            var user = HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user))
            {
                HttpContext.Session.SetString("goto", "/Projecten");
                return Redirect("/Login");
                //moet dan ook nog in een cookie een goto worden meeverstuurd in dit geval goto projecten.
            }
            return null;
        }
    }
}
