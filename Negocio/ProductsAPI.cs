using Negocio.Models;
using System.ComponentModel;
using System.Text.Json.Nodes;


namespace Negocio
{
    public class ProductsAPI
    {
        public List<Product> GetAll()
        {
            return Datos.listaProductos.OrderBy(item => item.Id).ToList(); 
        }
        public Product GetById(int id)
        {
            return Datos.listaProductos.Where(item => item.Id == id).First();
        }
        public void Update(Product producto){ }
        public int Delete(int id) 
        {           
           return Datos.listaProductos.RemoveAll(item => item.Id == id);
        }
        public Product Put(Product prod)
        {            
            var product = Datos.listaProductos.Where(item => item.Id == prod.Id).First();
            Datos.listaProductos.Remove(product);            
            Datos.Agregar(prod);
            return product;            
        }
        public Product Post(Product producto)
        {
            Datos.Agregar(producto);
            return producto;            
        }
    }
}