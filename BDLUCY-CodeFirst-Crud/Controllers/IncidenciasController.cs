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
    public class IncidenciasController : Controller
    {
        private readonly BdLucyContext _context;

        public IncidenciasController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Incidencias
        public async Task<IActionResult> Index()
        {
            var bdLucyContext = _context.Incidencias.Include(i => i.producto);
            return View(await bdLucyContext.ToListAsync());
        }

        // GET: Incidencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Incidencias == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencias
                .Include(i => i.producto)
                .FirstOrDefaultAsync(m => m.Codigo_Incidencia == id);
            if (incidencia == null)
            {
                return NotFound();
            }

            return View(incidencia);
        }

        // GET: Incidencias/Create
        public IActionResult Create()
        {
            ViewData["Codigo_Producto"] = new SelectList(_context.Productos, "Codigo_Producto", "Codigo_De_Barra");
            return View();
        }

        // POST: Incidencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo_Incidencia,Codigo_Producto,Descripcion_Incidencia,Cantidad_Incidencia,Fecha_Incidencia")] Incidencia incidencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codigo_Producto"] = new SelectList(_context.Productos, "Codigo_Producto", "Codigo_De_Barra", incidencia.Codigo_Producto);
            return View(incidencia);
        }

        // GET: Incidencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Incidencias == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }
            ViewData["Codigo_Producto"] = new SelectList(_context.Productos, "Codigo_Producto", "Codigo_De_Barra", incidencia.Codigo_Producto);
            return View(incidencia);
        }

        // POST: Incidencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo_Incidencia,Codigo_Producto,Descripcion_Incidencia,Cantidad_Incidencia,Fecha_Incidencia")] Incidencia incidencia)
        {
            if (id != incidencia.Codigo_Incidencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidenciaExists(incidencia.Codigo_Incidencia))
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
            ViewData["Codigo_Producto"] = new SelectList(_context.Productos, "Codigo_Producto", "Codigo_De_Barra", incidencia.Codigo_Producto);
            return View(incidencia);
        }

        // GET: Incidencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Incidencias == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencias
                .Include(i => i.producto)
                .FirstOrDefaultAsync(m => m.Codigo_Incidencia == id);
            if (incidencia == null)
            {
                return NotFound();
            }

            return View(incidencia);
        }

        // POST: Incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Incidencias == null)
            {
                return Problem("Entity set 'BdLucyContext.Incidencias'  is null.");
            }
            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia != null)
            {
                _context.Incidencias.Remove(incidencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidenciaExists(int id)
        {
          return _context.Incidencias.Any(e => e.Codigo_Incidencia == id);
        }
    }
}
