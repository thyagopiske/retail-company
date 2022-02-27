using RetailCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int productId);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }
}
