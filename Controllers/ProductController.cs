using Microsoft.AspNetCore.Mvc;
using RetailCompany.DTOs;
using RetailCompany.Entities;
using RetailCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        [HttpPost]
        public async Task AddProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price
            };

            await _productRepository.AddProductAsync(product);
        }

        [HttpPut]
        public async Task UpdateProduct(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
