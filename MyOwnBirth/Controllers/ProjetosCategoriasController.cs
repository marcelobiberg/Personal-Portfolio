using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOwnBirth.Data;
using MyOwnBirth.Models;

namespace MyOwnBirth.Controllers
{
    public class ProjetosCategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjetosCategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjetosCategorias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjetosCategorias.Include(p => p.Projeto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjetosCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetosCategorias = await _context.ProjetosCategorias
                .Include(p => p.Projeto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projetosCategorias == null)
            {
                return NotFound();
            }

            return View(projetosCategorias);
        }

        // GET: ProjetosCategorias/Create
        public IActionResult Create()
        {
            ViewData["ProjetoID"] = new SelectList(_context.Projetos, "ID", "ID");
            return View();
        }

        // POST: ProjetosCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,IsActive,ProjetoID")] ProjetosCategorias projetosCategorias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projetosCategorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoID"] = new SelectList(_context.Projetos, "ID", "ID", projetosCategorias.ProjetoID);
            return View(projetosCategorias);
        }

        // GET: ProjetosCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetosCategorias = await _context.ProjetosCategorias.FindAsync(id);
            if (projetosCategorias == null)
            {
                return NotFound();
            }
            ViewData["ProjetoID"] = new SelectList(_context.Projetos, "ID", "ID", projetosCategorias.ProjetoID);
            return View(projetosCategorias);
        }

        // POST: ProjetosCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,IsActive,ProjetoID")] ProjetosCategorias projetosCategorias)
        {
            if (id != projetosCategorias.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projetosCategorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetosCategoriasExists(projetosCategorias.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoID"] = new SelectList(_context.Projetos, "ID", "ID", projetosCategorias.ProjetoID);
            return View(projetosCategorias);
        }

        // GET: ProjetosCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetosCategorias = await _context.ProjetosCategorias
                .Include(p => p.Projeto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (projetosCategorias == null)
            {
                return NotFound();
            }

            return View(projetosCategorias);
        }

        // POST: ProjetosCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projetosCategorias = await _context.ProjetosCategorias.FindAsync(id);
            _context.ProjetosCategorias.Remove(projetosCategorias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetosCategoriasExists(int id)
        {
            return _context.ProjetosCategorias.Any(e => e.ID == id);
        }
    }
}
