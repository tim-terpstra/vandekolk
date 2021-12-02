using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace kis20.Pages
{
    public class ProjectenModel : PageModel
    {
        private readonly ILogger<ProjectenModel> _logger;

        public ProjectenModel(ILogger<ProjectenModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var user = HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user))
            {
                return Redirect("/Login");
                //moet dan ook nog in een cookie een goto worden meeverstuurd in dit geval goto projecten.
            }
            return null;
        }
        public void OnYes()
        {
        }
    }
}
