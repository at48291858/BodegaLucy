using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDLUCY_CodeFirst_Crud.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace BDLUCY_CodeFirst_Crud.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly BdLucyContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductoesController(BdLucyContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Productoes
        public async Task<IActionResult> Index(string buscar)
        {
            var productos = from producto in _context.Productos.Include(p => p.marca).Include(p => p.presentacion).Include(p => p.subcategoria)
                            select producto;
            if (!String.IsNullOrEmpty(buscar))
            {
                productos = productos.Where(p => p.Codigo_De_Barra!.Contains(buscar) || p.Nombre_Producto!.Contains(buscar) || p.marca.Nombre_Marca!.Contains(buscar)
                || p.presentacion.Nombre_Presentacion!.Contains(buscar) || p.subcategoria.Nombre_Subcategoria!.Contains(buscar));
            }

            return View(await productos.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.marca)
                .Include(p => p.presentacion)
                .Include(p => p.subcategoria)
                .FirstOrDefaultAsync(m => m.Codigo_Producto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["Codigo_Marca"] = new SelectList(_context.Marcas, "Codigo_Marca", "Nombre_Marca");
            ViewData["Codigo_Presentacion"] = new SelectList(_context.Presentacions, "Codigo_Presentacion", "Nombre_Presentacion");
            ViewData["Codigo_Subcategoria"] = new SelectList(_context.Subcategorias, "Codigo_Subcategoria", "Nombre_Subcategoria");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo_Producto,Codigo_Subcategoria,Codigo_Presentacion,Codigo_Marca,Nombre_Producto,Codigo_De_Barra,Stock_Producto,Precio_Compra_Producto,Precio_Venta_Producto,Descripcion_Producto,NombreImage,Estado_Producto")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                /*string wwwRootPath = _environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(producto.ArchivoImagen.FileName);
                string extension = Path.GetExtension(producto.ArchivoImagen.FileName);
                producto.NombreImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await producto.ArchivoImagen.CopyToAsync(fileStream);
                }*/
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codigo_Marca"] = new SelectList(_context.Marcas, "Codigo_Marca", "Nombre_Marca", producto.Codigo_Marca);
            ViewData["Codigo_Presentacion"] = new SelectList(_context.Presentacions, "Codigo_Presentacion", "Nombre_Presentacion", producto.Codigo_Presentacion);
            ViewData["Codigo_Subcategoria"] = new SelectList(_context.Subcategorias, "Codigo_Subcategoria", "Nombre_Subcategoria", producto.Codigo_Subcategoria);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Codigo_Marca"] = new SelectList(_context.Marcas, "Codigo_Marca", "Nombre_Marca", producto.Codigo_Marca);
            ViewData["Codigo_Presentacion"] = new SelectList(_context.Presentacions, "Codigo_Presentacion", "Nombre_Presentacion", producto.Codigo_Presentacion);
            ViewData["Codigo_Subcategoria"] = new SelectList(_context.Subcategorias, "Codigo_Subcategoria", "Nombre_Subcategoria", producto.Codigo_Subcategoria);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo_Producto,Codigo_Subcategoria,Codigo_Presentacion,Codigo_Marca,Nombre_Producto,Codigo_De_Barra,Stock_Producto,Precio_Compra_Producto,Precio_Venta_Producto,Descripcion_Producto,NombreImage,Estado_Producto")] Producto producto)
        {
            if (id != producto.Codigo_Producto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Save image to wwwroot/image
                    /*string wwwRootPath = _environment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(producto.ArchivoImagen.FileName);
                    string extension = Path.GetExtension(producto.ArchivoImagen.FileName);
                    producto.NombreImage = fileName;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await producto.ArchivoImagen.CopyToAsync(fileStream);
                    }*/
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Codigo_Producto))
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
            ViewData["Codigo_Marca"] = new SelectList(_context.Marcas, "Codigo_Marca", "Nombre_Marca", producto.Codigo_Marca);
            ViewData["Codigo_Presentacion"] = new SelectList(_context.Presentacions, "Codigo_Presentacion", "Nombre_Presentacion", producto.Codigo_Presentacion);
            ViewData["Codigo_Subcategoria"] = new SelectList(_context.Subcategorias, "Codigo_Subcategoria", "Nombre_Subcategoria", producto.Codigo_Subcategoria);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.marca)
                .Include(p => p.presentacion)
                .Include(p => p.subcategoria)
                .FirstOrDefaultAsync(m => m.Codigo_Producto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'BdLucyContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return _context.Productos.Any(e => e.Codigo_Producto == id);
        }
    }
}
