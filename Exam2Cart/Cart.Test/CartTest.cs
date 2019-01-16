using System;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cart.Api.Controllers;
using System.Collections.Generic;

namespace Cart.Test
{
    public class CartTest
    {
        List<Product> MockProduct = new List<Product>
        {
            new Product
            {
                id = "Prod01",
                Name="iPhone",
                Price = 15000
            },
            new Product
            {
                id = "Prod02",
                Name="Android",
                Price = 9000
            },
            new Product
            {
                id = "Prod03",
                Name="NPhone",
                Price = 3000
            }
        };

        List<CartProduct> MockProductInCart = new List<CartProduct>
        {
            new CartProduct
            {
                id = "CProd01",
                Product = new Product
                {
                    id = "Prod01",
                    Name="iPhone",
                    Price = 15000
                },
                Amount = 5
            },
            new CartProduct
            {
                id = "CProd02",
                Product = new Product
                {
                    id = "Prod02",
                    Name="Android",
                    Price = 9000
                },
                Amount = 1
            }
        };

        [Theory]
        [InlineData(new string[3] { "Prod01", "Prod02", "Prod03" }, new string[3] { "iPhone", "Android", "NPhone" }, new double[3] { 15000, 9000, 3000 })]
        public void GetProductsTest(string[] expectedId, string[] expectedName, double[] expectedPrice)
        {
            var svc = new CartController();
            CartController.Products = MockProduct;
            var result = svc.GetProducts().Value.ToList();
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(result[i].id, expectedId[i]);
                Assert.Equal(result[i].Name, expectedName[i]);
                Assert.Equal(result[i].Price, expectedPrice[i]);
            };
        }

        [Theory]
        [InlineData(new string[2] { "CProd01", "CProd02" }, new string[2] { "Prod01", "Prod02" }, new int[2] { 5, 1 })]
        public void GetProductsInCartTest(string[] expectedId, string[] expectedProductId, int[] expectedAmount)
        {
            var svc = new CartController();
            CartController.CartProducts = MockProductInCart;
            var result = svc.GetProductInCart().Value.ToList();
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(result[i].id, expectedId[i]);
                Assert.Equal(result[i].Product.id, expectedProductId[i]);
                Assert.Equal(result[i].Amount, expectedAmount[i]);
            };
        }

        [Theory]
        [InlineData("XProduct", 50000, 4)]
        [InlineData("SProduct", 12000, 4)]
        public void AddNewProductTest(string name, double price, int expectedCount)
        {
            var svc = new CartController();
            CartController.Products = MockProduct;
            svc.AddNewProduct(new Product { Name = name, Price = price });

            var result = svc.GetProducts().Value.ToList();
            Assert.Equal(result.Count, expectedCount);

            var haveInsertItem = result.Any(it => it.Name == name && it.Price == price);
            Assert.True(haveInsertItem);
        }

        [Theory]
        [InlineData("Prod03", 5, 3, 5)]
        [InlineData("Prod01", 6, 2, 11)]
        public void AddProductToCartTest(string proId, int amount, int expectedProductCount, int expectedTotalAmout)
        {
            var svc = new CartController();
            CartController.CartProducts = MockProductInCart;
            CartController.Products = MockProduct;

            svc.AddProductToCart(proId, amount);

            var result = svc.GetProductInCart().Value.ToList();
            Assert.Equal(result.Count, expectedProductCount);

            var haveCorrectAmout = result.Any(it => it.Product.id == proId && it.Amount == expectedTotalAmout);
            Assert.True(haveCorrectAmout);
        }
    }
}
