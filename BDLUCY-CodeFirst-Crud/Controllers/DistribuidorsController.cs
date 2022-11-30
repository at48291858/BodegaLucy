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
    public class DistribuidorsController : Controller
    {
        private readonly BdLucyContext _context;

        public DistribuidorsController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Distribuidors
        public async Task<IActionResult> Index()
        {
              return View(await _context.Distribuidor.ToListAsync());
        }

        // GET: Distribuidors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Distribuidor == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidor
                .FirstOrDefaultAsync(m => m.Codigo_Distribuidor == id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // GET: Distribuidors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Distribuidors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo_Distribuidor,Razon_Social_Distribuidor,RUC_Distribuidor,Direccion_Distribuidor,Telefono_Distribuidor,Nombre_Contacto,Telefono_Contacto,Estado_Distribuidor")] Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distribuidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distribuidor);
        }

        // GET: Distribuidors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Distribuidor == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidor.FindAsync(id);
            if (distribuidor == null)
            {
                return NotFound();
            }
            return View(distribuidor);
        }

        // POST: Distribuidors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo_Distribuidor,Razon_Social_Distribuidor,RUC_Distribuidor,Direccion_Distribuidor,Telefono_Distribuidor,Nombre_Contacto,Telefono_Contacto,Estado_Distribuidor")] Distribuidor distribuidor)
        {
            if (id != distribuidor.Codigo_Distribuidor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distribuidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistribuidorExists(distribuidor.Codigo_Distribuidor))
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
            return View(distribuidor);
        }

        // GET: Distribuidors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Distribuidor == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidor
                .FirstOrDefaultAsync(m => m.Codigo_Distribuidor == id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // POST: Distribuidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Distribuidor == null)
            {
                return Problem("Entity set 'BdLucyContext.Distribuidor'  is null.");
            }
            var distribuidor = await _context.Distribuidor.FindAsync(id);
            if (distribuidor != null)
            {
                _context.Distribuidor.Remove(distribuidor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistribuidorExists(int id)
        {
          return _context.Distribuidor.Any(e => e.Codigo_Distribuidor == id);
        }
    }
}
