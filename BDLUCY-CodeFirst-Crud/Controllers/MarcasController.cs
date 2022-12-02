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
    public class MarcasController : Controller
    {
        private readonly BdLucyContext _context;

        public MarcasController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Marcas
        public async Task<IActionResult> Index(string buscar)
        {
            var marcas = from marca in _context.Marcas.Include(m => m.empresa)
                          select marca;
            if (!String.IsNullOrEmpty(buscar))
            {
                marcas = marcas.Where(s => s.Nombre_Marca!.Contains(buscar) || s.empresa.Nombre_Empresa!.Contains(buscar));
            }

            return View(await marcas.ToListAsync());
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["Codigo_Empresa"] = new SelectList(_context.Empresas, "Codigo_Empresa", "Nombre_Empresa");
                return View(new Marca());
            }
            else
            {
                var marca = await _context.Marcas.FindAsync(id);
                if (marca == null)
                {
                    return NotFound();
                }
                ViewData["Codigo_Empresa"] = new SelectList(_context.Empresas, "Codigo_Empresa", "Nombre_Empresa");
                return View(marca);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Codigo_Marca,Codigo_Empresa,Nombre_Marca,Descripcion_Marca")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(marca);
                    await _context.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(marca);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MarcaExists(marca.Codigo_Marca))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                ViewData["Codigo_Empresa"] = new SelectList(_context.Empresas, "Codigo_Empresa", "Nombre_Empresa");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Marcas.ToList()) });
            }
            ViewData["Codigo_Empresa"] = new SelectList(_context.Empresas, "Codigo_Empresa", "Nombre_Empresa");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", marca) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Marcas.ToList()) });
        }

        private bool MarcaExists(int id)
        {
          return _context.Marcas.Any(e => e.Codigo_Marca == id);
        }
    }
}
