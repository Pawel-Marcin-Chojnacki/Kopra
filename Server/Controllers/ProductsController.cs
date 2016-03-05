 using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{

    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Zupa", Category = "Zywnosc", Price = 3 },
            new Product { Id = 2, Name = "Jablka", Category = "Warzywa", Price = 4.99M },
            new Product { Id = 2, Name = "Brzoza", Category = "Drzewa", Price = 2M }
        };

        Product[] products2 = new Product[]
        {
            new Product { Id = 1, Name = "Dupa", Category = "Zywnosc", Price = 3 },
            new Product { Id = 2, Name = "Banan", Category = "Warzywa", Price = 4.99M },
            new Product { Id = 2, Name = "Śmietana", Category = "Drzewa", Price = 2M }
        };


        public IEnumerable<Product> GetProduct()
        {
            return products;
        }

        public IHttpActionResult GetAllProduct(int Id)
        {
            var product = products.FirstOrDefault((p) => p.Id == Id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}