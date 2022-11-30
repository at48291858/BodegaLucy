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
    public class SubcategoriasController : Controller
    {
        private readonly BdLucyContext _context;

        public SubcategoriasController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Subcategorias
        public async Task<IActionResult> Index(string buscar)
        {
            var subcategorias = from marca in _context.Subcategorias.Include(s => s.categoria)
                                select marca;
            if (!String.IsNullOrEmpty(buscar))
            {
                subcategorias = subcategorias.Where(s => s.Nombre_Subcategoria!.Contains(buscar) || s.categoria.Nombre_Categoria!.Contains(buscar));
            }

            return View(await subcategorias.ToListAsync());
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["Codigo_Categoria"] = new SelectList(_context.Categorias, "Codigo_Categoria", "Nombre_Categoria");
                return View(new Subcategoria());
            }
            else
            {
                var subcategoria = await _context.Subcategorias.FindAsync(id);
                if (subcategoria == null)
                {
                    return NotFound();
                }
                ViewData["Codigo_Categoria"] = new SelectList(_context.Categorias, "Codigo_Categoria", "Nombre_Categoria");
                return View(subcategoria);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Codigo_Subcategoria,Codigo_Categoria,Nombre_Subcategoria,Descripcion_Subcategoria,Estado_Subcategoria")] Subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(subcategoria);
                    await _context.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(subcategoria);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SubcategoriaExists(subcategoria.Codigo_Subcategoria))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                ViewData["Codigo_Categoria"] = new SelectList(_context.Categorias, "Codigo_Categoria", "Nombre_Categoria");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Subcategorias.ToList()) });
            }
            ViewData["Codigo_Categoria"] = new SelectList(_context.Categorias, "Codigo_Categoria", "Nombre_Categoria");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", subcategoria) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategoria = await _context.Subcategorias.FindAsync(id);
            _context.Subcategorias.Remove(subcategoria);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Subcategorias.ToList()) });
        }

        private bool SubcategoriaExists(int id)
        {
          return _context.Subcategorias.Any(e => e.Codigo_Subcategoria == id);
        }
    }
}
