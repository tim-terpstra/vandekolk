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
    public class TrajectenModel : PageModel
    {
        private readonly ILogger<TrajectenModel> _logger;
        public List<LijstTraject> trajecten;
        public List<Personeel> personeel;
        public int err;

        public TrajectenModel(ILogger<TrajectenModel> logger)
        {
            _logger = logger;

            try
            {
                trajecten = new Database().getTrajectenlijst();
                personeel = new Database().getCalculator();
                err = 1;
            }
            catch (SqlException)
            {
                err = -1;
                return;
            }
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
        public IActionResult OnPost()
        {
            string naam = Request.Form["naam"];
            string plaats = Request.Form["plaats"];
            string calc = Request.Form["calc"];

            string aanbiedingRetourString = Request.Form["aanbiedingRetour"];
            string datumCalculatieGereedString = Request.Form["datumCalculatieGereed"];

            DateTime aanbiedingRetour = DateTime.Parse(aanbiedingRetourString);
            DateTime datumCalculatieGereed = DateTime.Parse(datumCalculatieGereedString); 
            
            var result = new Database().saveTraject(naam, plaats, calc, aanbiedingRetour, datumCalculatieGereed);
            if (result < 0)
            {
                return Redirect("/503");
            }
            return null;
        }
    }
}
