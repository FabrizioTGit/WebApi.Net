using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductsAPI apiMetodos = new ProductsAPI();

        // GET: api/<ValuesController>/products
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            try
            {                
                List<Product> products = apiMetodos.GetAll();

                if (products == null || !products.Any())
                {
                    return BadRequest(new { Message = "No se encontraron productos." });
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        // GET: api/<ValuesController>/categories
        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            try
            {
                List<string> Categories = apiMetodos.GetAllCategories();

                if (Categories == null || !Categories.Any())
                {
                    return BadRequest(new { Message = "No se encontraron categorias."});
                }

                return Ok(Categories);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { ex.Message });
            }           
        }

        // GET api/<ValuesController>/products/5
        [HttpGet("products/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Product product = apiMetodos.GetById(id);
                if (product == null)
                {
                    throw new Exception("No se encontro el id");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {ex.Message});
            }
        }

        // POST api/<ValuesController>/products        
        [HttpPost("products")]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                Product createdProduct = apiMetodos.Post(product);
                if (createdProduct == null)
                {
                    throw new Exception("Error al crear el producto.");
                }
                return StatusCode(201, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }


        // PUT api/<ValuesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                Product p = apiMetodos.Put(product);

                if (p == null)
                {
                    return BadRequest(new { Message = "No se encontro el producto para actualizar." });
                }

                return Ok(p);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int rowsAffected = apiMetodos.Delete(id);

                if (rowsAffected == 0)
                {
                    return BadRequest(new { Message = "No se encontro el producto para eliminar." });
                }

                return Ok(new { Message = "Producto eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
