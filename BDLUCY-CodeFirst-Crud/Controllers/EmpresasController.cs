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
    public class EmpresasController : Controller
    {
        private readonly BdLucyContext _context;

        public EmpresasController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index(string buscar)
        {
            var empresas = from empresa in _context.Empresas
                           select empresa;
            if (!String.IsNullOrEmpty(buscar))
            {
                empresas = empresas.Where(s => s.Nombre_Empresa!.Contains(buscar));
            }
            return View(await empresas.ToListAsync());
        }

        // GET: Transaction/AddOrEdit(Insert)
        // GET: Transaction/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Empresa());
            else
            {
                var empresa = await _context.Empresas.FindAsync(id);
                if (empresa == null)
                {
                    return NotFound();
                }
                return View(empresa);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Codigo_Empresa,Nombre_Empresa,Descripcion_Empresa")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(empresa);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(empresa);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmpresaExists(empresa.Codigo_Empresa))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Empresas.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", empresa) });
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Empresas.ToList()) });
        }

        private bool EmpresaExists(int id)
        {
          return _context.Empresas.Any(e => e.Codigo_Empresa == id);
        }
    }
}
