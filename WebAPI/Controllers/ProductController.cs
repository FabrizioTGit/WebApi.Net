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
        ProductsAPI api = new ProductsAPI();

        // GET: api/<ValuesController>/products
        [HttpGet("products")]
        public List<Product> Get()
        {
            return api.GetAll();
        }

        // GET api/<ValuesController>/products/5
        [HttpGet("products/{id}")]
        public Product Get(int id)
        {
            return api.GetById(id);
        }

        // POST api/<ValuesController>/products
        [HttpPost("products")]
        public Product Post([FromBody] Product producto)
        {
            return api.Post(producto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public Product Put([FromBody] Product product)
        {
            return api.Put(product);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            api.Delete(id);
        }
    }
}
