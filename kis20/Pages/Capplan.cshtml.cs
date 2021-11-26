using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kis20.Pages
{
    public class CapplanModel : PageModel
    {
        private readonly ILogger<CapplanModel> _logger;

        public CapplanModel(ILogger<CapplanModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnYes()
        {
            Console.WriteLine("aaa");
        }
    }
}
