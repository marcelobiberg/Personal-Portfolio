using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biberg.MyPortfolio.Data;

namespace Biberg.MyPortfolio.Pages.Skill
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Data.Skill> Skill { get;set; }

        public async Task OnGetAsync()
        {
            Skill = await _context.Skills.ToListAsync();
        }
    }
}
