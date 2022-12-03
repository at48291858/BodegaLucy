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
    public class ClientesController : Controller
    {
        private readonly BdLucyContext _context;

        public ClientesController(BdLucyContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string buscar)
        {
            var clientes = from a in _context.Clientes
                          select a;
            if (!String.IsNullOrEmpty(buscar))
            {
                clientes = clientes.Where(s => s.Nombre_Cliente!.Contains(buscar) || s.Documento_Cliente!.Contains(buscar));
            }
            return View(await clientes.ToListAsync());
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {                
                return View(new Cliente());
            }
            else
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Codigo_Cliente,Nombre_Cliente,Apellido_Paterno_Cliente,Apellido_Materno_Cliente,Tipo_Documento_Cliente,Documento_Cliente")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(cliente);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClienteExists(cliente.Codigo_Cliente))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Clientes.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", cliente) });
        }


        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Codigo_Cliente == id);
        }
    }
}