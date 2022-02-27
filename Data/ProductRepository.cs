using NHibernate;
using RetailCompany.Entities;
using RetailCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISession _session;

        public ProductRepository(ISession session)
        {
            _session = session;
        }

        public async Task AddProductAsync(Product product)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(product);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var product = _session.GetAsync<Product>(productId);
                await _session.DeleteAsync(product);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }

        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _session.GetAsync<Product>(productId);
        }

        public async Task UpdateProductAsync(Product product)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(product);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
