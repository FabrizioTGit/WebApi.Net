using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class Datos
    {
        static public List<Product> listProducts = new List<Product>() { new Product(1, "Banana", 200), new Product(2,"Manzana",250), new Product(3, "Naranja", 300) }; 
        static public void Agregar(Product product)
        {
            listProducts.Add(product);
        }
        static public bool Existe(int id)
        {            
            return listProducts.Any(p => p.Id == id);
        }
    }
}
