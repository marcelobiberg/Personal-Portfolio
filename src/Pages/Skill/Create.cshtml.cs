using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolio.Data;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Pages.Skill
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public bool IsChecked { get; set; }

        [BindProperty]
        public Data.Skill skill { get; set; }

        public IActionResult OnGet()
        {
            //Popula dropdownlist de 10 - 100
            ViewData["Score"] = FillNumeric(1, 100);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Score"] = FillNumeric(1, 100);
                return Page();
            }

            if (IsChecked)
            {
                ViewData["Score"] = FillNumeric(1, 100);
                await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();

                ModelState.Clear();
                return RedirectToPage("./Create");
            }
            else
            {
                await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }

        public IEnumerable<Int32> FillNumeric(int star, int end)
        {
            return Enumerable.Range(star, end).Select(x => x * 10).Take(10);
        }
    }
}