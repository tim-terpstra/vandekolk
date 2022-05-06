using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;
using kis20.Business;


namespace kis20.Pages
{
    public class CapplanModel : PageModel
    {
        private readonly ILogger<CapplanModel> _logger;

        public CapplanModel(ILogger<CapplanModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var user = HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user))
            {
                HttpContext.Session.SetString("goto", "/Capplan");
                return Redirect("/Login");
            }
            return null;
        }
    }
}
