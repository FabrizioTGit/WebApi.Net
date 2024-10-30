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
        public List<Product> GetProducts()
        {
            ProductsAPI productsAPI = new ProductsAPI();
            return productsAPI.GetAll();
        }
        // GET: api/<ValuesController>/categories
        [HttpGet("categories")]
        public List<string> GetCategories()
        {
            ProductsAPI productsAPI = new ProductsAPI();
            return productsAPI.GetAllCategories();
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
                    throw new Exception("No se encontró el id");
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
            Product p;
            try
            {
                p = apiMetodos.Post(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode(201, p);

        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            Product p = apiMetodos.Put(product);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(200, p);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //revisar
            if (apiMetodos.Delete(id) == 0)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(200);
            }

        }
    }
}
