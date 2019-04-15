using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biberg.MyPortfolio.Data;
using System.ComponentModel.DataAnnotations;

namespace Biberg.MyPortfolio.Pages.Skill
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Data.Skill Skill { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skill = await _context.Skills.SingleOrDefaultAsync(m => m.ID == id);

            if (Skill == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SkillExists(Skill.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw(ex.InnerException);
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SkillExists(Guid id)
        {
            return _context.Skills.Any(e => e.ID == id);
        }
    }
}
