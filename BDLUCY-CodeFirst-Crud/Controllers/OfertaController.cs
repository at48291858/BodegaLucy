using BDLUCY_CodeFirst_Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BDLUCY_CodeFirst_Crud.Controllers
{
    public class OfertasController : Controller
    {
        private readonly BdLucyContext db;
        public OfertasController(BdLucyContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Oferta> ofertas = db.Ofertas.Include(p => p.producto).ToList();
            return View(ofertas);
        }

        [HttpGet]
        public IActionResult CrearEditar()
        {
            ViewBag.productos = new SelectList(db.Productos.ToList());
            return View();
           
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerOfertas()
        {
            var obtn = await db.Ofertas.ToListAsync();
            return Json(new { data = obtn });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                await db.Ofertas.AddAsync(oferta);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(CrearEditar));
            }
            return View(oferta);
        }

    }
}