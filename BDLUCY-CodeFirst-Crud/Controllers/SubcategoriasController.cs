using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDLUCY_CodeFirst_Crud.Models;

namespace BDLUCY_CodeFirst_Crud.Controllers
{
    public class SubcategoriasController : Controller
    {
        private readonly BdLucyContext _context;

        public SubcategoriasController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Subcategorias
        public async Task<IActionResult> Index()
        {
            var bdLucyContext = _context.Subcategorias.Include(s => s.categoria);
            return View(await bdLucyContext.ToListAsync());
        }

        // GET: Subcategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subcategorias == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategorias
                .Include(s => s.categoria)
                .FirstOrDefaultAsync(m => m.Codigo_Subcategoria == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // GET: Subcategorias/Create
        public IActionResult Create()
        {
            ViewData["Codigo_Categoria"] = new SelectList(_context.Categorias, "Codigo_Categoria", "Nombre_Categoria");
            return View();
        }

        // POST: Subcategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo_Subcategoria,Codigo_Categoria,Nombre_Subcategoria,Descripcion_Subcategoria,Estado_Subcategoria")] Subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codigo_Categoria"] = new SelectList(_context.Categorias, "Codigo_Categoria", "Nombre_Categoria", subcategoria.Codigo_Categoria);
            return View(subcategoria);
        }

        // GET: Subcategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subcategorias == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategorias.FindAsync(id);
            if (subcategoria == null)
            {
                return NotFound();
            }
            ViewData["Codigo_Categoria"] = new SelectList(_context.Categorias, "Codigo_Categoria", "Nombre_Categoria", subcategoria.Codigo_Categoria);
            return View(subcategoria);
        }

        // POST: Subcategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo_Subcategoria,Codigo_Categoria,Nombre_Subcategoria,Descripcion_Subcategoria,Estado_Subcategoria")] Subcategoria subcategoria)
        {
            if (id != subcategoria.Codigo_Subcategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoriaExists(subcategoria.Codigo_Subcategoria))
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
            ViewData["Codigo_Categoria"] = new SelectList(_context.Categorias, "Codigo_Categoria", "Nombre_Categoria", subcategoria.Codigo_Categoria);
            return View(subcategoria);
        }

        // GET: Subcategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subcategorias == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategorias
                .Include(s => s.categoria)
                .FirstOrDefaultAsync(m => m.Codigo_Subcategoria == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // POST: Subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subcategorias == null)
            {
                return Problem("Entity set 'BdLucyContext.Subcategorias'  is null.");
            }
            var subcategoria = await _context.Subcategorias.FindAsync(id);
            if (subcategoria != null)
            {
                _context.Subcategorias.Remove(subcategoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoriaExists(int id)
        {
          return _context.Subcategorias.Any(e => e.Codigo_Subcategoria == id);
        }
    }
}
