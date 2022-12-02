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
    public class Detalle_CompraController : Controller
    {
        private readonly BdLucyContext _context;

        public Detalle_CompraController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Detalle_Compra
        public async Task<IActionResult> Index()
        {
            var bdLucyContext = _context.Detalle_Compras.Include(d => d.compra).Include(d => d.paquete);
            return View(await bdLucyContext.ToListAsync());
        }

        // GET: Detalle_Compra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalle_Compras == null)
            {
                return NotFound();
            }

            var detalle_Compra = await _context.Detalle_Compras
                .Include(d => d.compra)
                .Include(d => d.paquete)
                .FirstOrDefaultAsync(m => m.Codigo_Detalle_Compra == id);
            if (detalle_Compra == null)
            {
                return NotFound();
            }

            return View(detalle_Compra);
        }

        // GET: Detalle_Compra/Create
        public IActionResult Create()
        {
            ViewData["Codigo_Compra"] = new SelectList(_context.Compras, "Codigo_Compra", "Codigo_Compra");
            ViewData["Codigo_Paquete"] = new SelectList(_context.Paquetes, "Codigo_Paquete", "Codigo_Paquete");
            return View();
        }

        // POST: Detalle_Compra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo_Detalle_Compra,Codigo_Compra,Codigo_Paquete,Cantidad,Precio_Unitario,Importe_Detalle_Compra")] Detalle_Compra detalle_Compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_Compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codigo_Compra"] = new SelectList(_context.Compras, "Codigo_Compra", "Codigo_Compra", detalle_Compra.Codigo_Compra);
            ViewData["Codigo_Paquete"] = new SelectList(_context.Paquetes, "Codigo_Paquete", "Codigo_Paquete", detalle_Compra.Codigo_Paquete);
            return View(detalle_Compra);
        }

        // GET: Detalle_Compra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalle_Compras == null)
            {
                return NotFound();
            }

            var detalle_Compra = await _context.Detalle_Compras.FindAsync(id);
            if (detalle_Compra == null)
            {
                return NotFound();
            }
            ViewData["Codigo_Compra"] = new SelectList(_context.Compras, "Codigo_Compra", "Codigo_Compra", detalle_Compra.Codigo_Compra);
            ViewData["Codigo_Paquete"] = new SelectList(_context.Paquetes, "Codigo_Paquete", "Codigo_Paquete", detalle_Compra.Codigo_Paquete);
            return View(detalle_Compra);
        }

        // POST: Detalle_Compra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo_Detalle_Compra,Codigo_Compra,Codigo_Paquete,Cantidad,Precio_Unitario,Importe_Detalle_Compra")] Detalle_Compra detalle_Compra)
        {
            if (id != detalle_Compra.Codigo_Detalle_Compra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_CompraExists(detalle_Compra.Codigo_Detalle_Compra))
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
            ViewData["Codigo_Compra"] = new SelectList(_context.Compras, "Codigo_Compra", "Codigo_Compra", detalle_Compra.Codigo_Compra);
            ViewData["Codigo_Paquete"] = new SelectList(_context.Paquetes, "Codigo_Paquete", "Codigo_Paquete", detalle_Compra.Codigo_Paquete);
            return View(detalle_Compra);
        }

        // GET: Detalle_Compra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalle_Compras == null)
            {
                return NotFound();
            }

            var detalle_Compra = await _context.Detalle_Compras
                .Include(d => d.compra)
                .Include(d => d.paquete)
                .FirstOrDefaultAsync(m => m.Codigo_Detalle_Compra == id);
            if (detalle_Compra == null)
            {
                return NotFound();
            }

            return View(detalle_Compra);
        }

        // POST: Detalle_Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalle_Compras == null)
            {
                return Problem("Entity set 'BdLucyContext.Detalle_Compras'  is null.");
            }
            var detalle_Compra = await _context.Detalle_Compras.FindAsync(id);
            if (detalle_Compra != null)
            {
                _context.Detalle_Compras.Remove(detalle_Compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_CompraExists(int id)
        {
          return _context.Detalle_Compras.Any(e => e.Codigo_Detalle_Compra == id);
        }
    }
}
