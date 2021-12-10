using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using kis20.Business;

namespace kis20.Pages
{
    public class TrajectenModel : PageModel
    {
        private readonly ILogger<TrajectenModel> _logger;
        public List<LijstTraject> trajecten;

        public TrajectenModel(ILogger<TrajectenModel> logger)
        {
            _logger = logger;
            trajecten = new Database().getTrajectenlijst();
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
        public void OnPost()
        {
        }
    }
}
