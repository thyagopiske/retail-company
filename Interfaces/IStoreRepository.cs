using RetailCompany.DTOs;
using RetailCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Interfaces
{
    public interface IStoreRepository
    {
        Task AddStoreAsync(Store store);
        Task<Store> GetStoreByIdAsync(int storeId);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(int storeId);
        IList<Store> GetAllStores();
    }
}
