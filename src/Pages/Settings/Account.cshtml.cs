using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biberg.MyPortfolio.Data;
using Biberg.MyPortfolio.Services.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Biberg.MyPortfolio.Pages.Settings
{
    public class AccountModel : PageModel
    {
        public AccountModel() 
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}