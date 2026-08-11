using Microsoft.AspNetCore.Mvc;
using WebApplicationProduct.Models;
using WebApplicationProduct.ServiceProduct;

namespace WebApplicationProduct.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private IServiceProduct _service;

        public ProductController(IServiceProduct service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound(); 
            }
            return Ok(product); 
        }

        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            var newProduct = _service.Add(product);
            return Ok(newProduct);
        }

        [HttpPut("{Id}")]
        public ActionResult<Product> UpdateProduct(int id, [FromBody] Product product)
        {
            var updatedProduct = _service.Update(id, product);
            if (updatedProduct == null)
            {
                return NotFound(); 
            }
            return Ok(updatedProduct); 
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _service.Delete(id);
            return NoContent(); 
        }
    }
}
