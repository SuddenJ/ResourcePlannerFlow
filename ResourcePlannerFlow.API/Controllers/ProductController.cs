using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Data;
using ProductManagementSystem.Data.Entities;

namespace ResourcePlannerFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductManagementContext _context = new ProductManagementContext();

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Product.ToList();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Product.FindAsync(id);
            return product == null ? NotFound(id) : Ok(product);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutById(int id, Models.Product updatedProduct)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound(id);
            }

            product.SKU = updatedProduct.SKU;
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.AverageCost = updatedProduct.AverageCost;
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound(1);
            }

            _context.Remove(product);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Models.Product product)
        {
            Product entityProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                AverageCost = product.AverageCost,
                SKU = product.SKU
            };
            _context.Product.Add(entityProduct);
            _context.SaveChanges();

            return Created($"api/product/{entityProduct.Id}", entityProduct);
        }
        
        

    }
}
