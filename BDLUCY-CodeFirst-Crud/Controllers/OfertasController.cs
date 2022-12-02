using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDLUCY_CodeFirst_Crud.Models;
using static BDLUCY_CodeFirst_Crud.Helper;

namespace BDLUCY_CodeFirst_Crud.Controllers
{
    public class OfertasController : Controller
    {
        private readonly BdLucyContext _context;

        public OfertasController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Ofertas
        public async Task<IActionResult> Index(string buscar)
        {
            var ofertas = from a in _context.Ofertas.Include(s => s.producto)
                          select a;
            if (!String.IsNullOrEmpty(buscar))
            {
                ofertas = ofertas.Where(s => s.producto.Nombre_Producto!.Contains(buscar));
            }
            return View(await ofertas.ToListAsync());
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["Codigo_Producto"] = new SelectList(_context.Productos, "Codigo_Producto", "Nombre_Producto");
                return View(new Oferta());
            }
            else
            {
                var oferta = await _context.Ofertas.FindAsync(id);
                if (oferta == null)
                {
                    return NotFound();
                }
                ViewData["Codigo_Producto"] = new SelectList(_context.Productos, "Codigo_Producto", "Nombre_Producto");
                return View(oferta);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Codigo_Oferta,Codigo_Producto,Cantidad_Oferta,Descuento_Oferta,Fecha_Inicio_Oferta,Fecha_Final_Oferta")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(oferta);
                    await _context.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(oferta);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!OfertaExists(oferta.Codigo_Oferta))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                ViewData["Codigo_Producto"] = new SelectList(_context.Productos, "Codigo_Producto", "Nombre_Producto");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Ofertas.ToList()) });
            }
            ViewData["Codigo_Producto"] = new SelectList(_context.Productos, "Codigo_Producto", "Nombre_Producto");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", oferta) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ofertas == null)
            {
                return Problem("Entity set 'BdLucyContext.Ofertas'  is null.");
            }
            var oferta = await _context.Ofertas.FindAsync(id);
            if (oferta != null)
            {
                _context.Ofertas.Remove(oferta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool OfertaExists(int id)
        {
            return _context.Ofertas.Any(e => e.Codigo_Oferta == id);
        }
    }
}