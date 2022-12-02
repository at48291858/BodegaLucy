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
    public class PresentacionsController : Controller
    {
        private readonly BdLucyContext _context;

        public PresentacionsController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Presentacions
        public async Task<IActionResult> Index(string buscar)
        {
            var presentaciones = from presentacion in _context.Presentacions
                                 select presentacion;
            if (!String.IsNullOrEmpty(buscar))
            {
                presentaciones = presentaciones.Where(s => s.Nombre_Presentacion!.Contains(buscar));
            }
            return View(await presentaciones.ToListAsync());
        }

        // GET: Transaction/AddOrEdit(Insert)
        // GET: Transaction/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Presentacion());
            else
            {
                var presentacion = await _context.Presentacions.FindAsync(id);
                if (presentacion == null)
                {
                    return NotFound();
                }
                return View(presentacion);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Codigo_Presentacion,Nombre_Presentacion,Siglas_Presentacion")] Presentacion presentacion)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(presentacion);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(presentacion);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PresentacionExists(presentacion.Codigo_Presentacion))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Presentacions.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", presentacion) });
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presentacion = await _context.Presentacions.FindAsync(id);
            _context.Presentacions.Remove(presentacion);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Presentacions.ToList()) });
        }

        private bool PresentacionExists(int id)
        {
          return _context.Presentacions.Any(e => e.Codigo_Presentacion == id);
        }
    }
}
