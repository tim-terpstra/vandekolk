using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kis20.Pages
{
    public class ProjectenModel : PageModel
    {
        private readonly ILogger<ProjectenModel> _logger;

        public ProjectenModel(ILogger<ProjectenModel> logger)
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
