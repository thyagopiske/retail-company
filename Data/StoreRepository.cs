using NHibernate;
using RetailCompany.DTOs;
using RetailCompany.Entities;
using RetailCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ISession _session;

        public StoreRepository(ISession session)
        {
            _session = session;
        }

        public async Task AddStoreAsync(Store store)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(store);
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

        public async Task DeleteStoreAsync(int storeId)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var store = _session.GetAsync<Store>(storeId);
                await _session.DeleteAsync(store);
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

        public async Task<Store> GetStoreByIdAsync(int storeId)
        {
            return await _session.GetAsync<Store>(storeId);
        }

        public async Task UpdateStoreAsync(Store store)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(store);
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

        public IList<Store> GetAllStores()
        {
            return _session.Query<Store>().ToList();
        }
    }
}
