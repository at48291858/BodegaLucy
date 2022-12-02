using BDLUCY_CodeFirst_Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BDLUCY_CodeFirst_Crud.Controllers
{
    public class RcompraController : Controller
    {
        private readonly BdLucyContext _bdLucyContext;

        public RcompraController(BdLucyContext bdLucyContext)
        {
            _bdLucyContext = bdLucyContext;
        }

        public IActionResult Index()
        {

            List<Compra> compras;
            compras = _bdLucyContext.Compras.ToList();


            return View(compras);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Codigo_Paquete"] = new SelectList(_bdLucyContext.Paquetes, "Codigo_Paquete", "Codigo_Paquete");

            ViewData["Codigo_Distribuidor"] = new SelectList(_bdLucyContext.Distribuidors, "Codigo_Distribuidor", "Razon_Social_Distribuidor");
            ViewData["Codigo_Usuario"] = new SelectList(_bdLucyContext.Usuarios, "Codigo_Usuario", "User_Usuario");
            Compra compra = new Compra();
            compra.Detalle_Compras.Add(new Detalle_Compra() { Codigo_Detalle_Compra = 1 });
            //compra.Detalle_Compras.Add(new Detalle_Compra() { Codigo_Detalle_Compra = 2 });
            //compra.Detalle_Compras.Add(new Detalle_Compra() { Codigo_Detalle_Compra = 3 });
            return View(compra);
        }


        [HttpPost]
        public IActionResult Create(Compra compra)
        {

            ViewData["Codigo_Paquete"] = new SelectList(_bdLucyContext.Paquetes, "Codigo_Paquete", "Codigo_Paquete");

            ViewData["Codigo_Distribuidor"] = new SelectList(_bdLucyContext.Distribuidors, "Codigo_Distribuidor", "Razon_Social_Distribuidor", compra.Codigo_Distribuidor);
            ViewData["Codigo_Usuario"] = new SelectList(_bdLucyContext.Usuarios, "Codigo_Usuario", "User_Usuario", compra.Codigo_Usuario);
            foreach (Detalle_Compra detalle_Compra in compra.Detalle_Compras)
            {
                if (detalle_Compra.Codigo_Paquete == 0)
                    compra.Detalle_Compras.Remove(detalle_Compra);

            }


            _bdLucyContext.Add(compra);
            _bdLucyContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
