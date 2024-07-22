using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly Datacontext _context;

        public ProductosController(ILogger<ProductosController> logger, Datacontext context){
            _logger= logger;
            _context= context;
        }
        [HttpGet(Name = "GetProductos")]
        public async Task<ActionResult<IEnumerable<Product>>> Getproductos()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<Product>> GetProducto(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if(producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public async Task <ActionResult<Product>> Post(Product producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetProducto", new { id = producto.id}, producto);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(int id, Product producto)
        {
            if(id != producto.id)
            {
                return BadRequest();
            }
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var producto = await _context.Products.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }
    }
}