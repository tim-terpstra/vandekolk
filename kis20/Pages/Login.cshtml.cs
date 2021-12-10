using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using kis20.Business;

namespace kis20.Pages
{
    public class LoginModel : PageModel
    {
        public string Message { get; set; }
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                return Redirect("/");
            }
            return null;
        }
        public void OnYes()
        {
        }
        public IActionResult OnPost()
        {
            string username = Request.Form["user"];
            string pswd = Request.Form["password"];
            string check =  Request.Form["check"];
            username = username.Trim();
            pswd = pswd.Trim();
            check = check.Trim();
            var db = new Database();
            Gebruiker user = db.getuser(username);
            if (user != null && user.Wachtwoord == pswd)
            {
                HttpContext.Session.SetString("user", username);
                //hier later laten redirecten naar GOTO in cookies
                return Redirect("/");

            }
             //hier nog sessies maken met machtegingen
             //hier nog zorgen dat je bijv max 3 keer in een uur kan inloggen
            return null;
        }
    }
}
