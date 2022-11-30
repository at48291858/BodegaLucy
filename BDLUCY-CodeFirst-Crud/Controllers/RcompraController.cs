using BDLUCY_CodeFirst_Crud.Models;
using Microsoft.AspNetCore.Mvc;


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
            Compra compra = new Compra();
            compra.Detalle_Compras.Add(new Detalle_Compra() { Codigo_Detalle_Compra = 1 });
            compra.Detalle_Compras.Add(new Detalle_Compra() { Codigo_Detalle_Compra = 2 });
            compra.Detalle_Compras.Add(new Detalle_Compra() { Codigo_Detalle_Compra = 3 });
            return View(compra);
        }


        [HttpPost]
        public IActionResult Create(Compra compra)
        {

            foreach (Detalle_Compra detalle_Compra in compra.Detalle_Compras) 
            {
                if(detalle_Compra.Codigo_Paquete == null || detalle_Compra.Codigo_Paquete == 0)
                    compra.Detalle_Compras.Remove(detalle_Compra);
            
            }


            _bdLucyContext.Add(compra);
            _bdLucyContext.SaveChanges();

            return RedirectToAction("Index");
        
        }



    }
}
