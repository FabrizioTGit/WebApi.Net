using Negocio.Models;
using System.ComponentModel;
using System.Text.Json.Nodes;


namespace Negocio
{
    public class ProductsAPI
    {
        public List<Product> GetAll()
        {            
            return Datos.listProducts.OrderBy(item => item.Id).ToList(); 
        }
        public Product GetById(int id)
        {            
            if (Datos.Existe(id))
            {
                return Datos.listProducts.Where(item => item.Id == id).First();
            }
            else
            {
                return null;
            }           
        }
        public void Update(Product producto){ }
        public int Delete(int id) 
        {            
            if (Datos.Existe(id))
            {
                return Datos.listProducts.RemoveAll(item => item.Id == id);
            }
            else
            {
                return 0;
            }                
        }
        public Product Put(Product prod)
        {            
            if (Datos.Existe(prod.Id))
            {
                if (prod == null)
                {
                    return null;
                }

                if (prod.Price < 0)
                {
                    return null;
                }

                var product = Datos.listProducts.Where(item => item.Id == prod.Id).First();
                Datos.listProducts.Remove(product);            
                Datos.Agregar(prod);
                return product;
            }
            else
                return null;
           
        }
        public Product Post(Product product)
        {                        
            Datos.Agregar(product);
            return product;
        }
    }
}