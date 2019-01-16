using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public static List<Product> Products= new List<Product>();
        public static List<CartProduct> CartProducts = new List<CartProduct>();

        [HttpGet]
        public ActionResult<IEnumerable<CartProduct>> GetProductInCart()
        {
            return CartProducts;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Products;
        }

        [HttpPost]
        public void AddNewProduct([FromBody]Product request)
        {
            request.id = Guid.NewGuid().ToString();
            Products.Add(request);
        }

        [HttpPut("{productId}/{amount}")]
        public void AddProductToCart(string productId, int amount)
        {
            var product = Products.FirstOrDefault(it => it.id == productId);
            var id = Guid.NewGuid().ToString();
            var cartProduct = new CartProduct
            {
                id = id,
                Amount = amount,
                Product = product
            };
            CartProducts.Add(cartProduct);
        }
    }

    public class Product
    {
        public string id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class CartProduct
    {
        public string id { get; set; }
        public Product Product{ get; set; }
        public int Amount { get; set; }
    }
}
