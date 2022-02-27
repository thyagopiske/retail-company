using Microsoft.AspNetCore.Mvc;
using NHibernate;
using RetailCompany.DTOs;
using RetailCompany.Entities;
using RetailCompany.Helpers;
using RetailCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailCompany.Controllers
{
    public class StoreController : BaseApiController
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;

        public StoreController(IStoreRepository storeRepository, IEmployeeRepository employeeRepository,
            IProductRepository productRepository)
        {
            _storeRepository = storeRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            return await _storeRepository.GetStoreByIdAsync(id);
        }

        [HttpPost]
        public async Task AddStore(StoreDto storeDto)
        {
            var store = new Store
            {
                Name = storeDto.Name
            };

            await _storeRepository.AddStoreAsync(store);
        }

        [Route("add-employee")]
        [HttpPut]
        public async Task AddEmployeeToStore(EmployeeStoreIds Ids)
        {
            var employeeId = Ids.employeeId;
            var storeId = Ids.storeId;
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            var store = await _storeRepository.GetStoreByIdAsync(storeId);

            employee.Store = store;
            store.Staff.Add(employee);
            await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        [Route("add-product")]
        [HttpPut]
        public async Task AddProductToStore(ProductStoreIds Ids)
        {
            var productId = Ids.productId;
            var storeId = Ids.storeId;
            var product = await _productRepository.GetProductByIdAsync(productId);
            var store = await _storeRepository.GetStoreByIdAsync(storeId);

            product.StoresStockedIn.Add(store);
            store.Products.Add(product);
            await _storeRepository.UpdateStoreAsync(store);
        }

        [HttpPut]
        public async Task UpdateStore(Store store)
        {
            await _storeRepository.UpdateStoreAsync(store);
        }

        [HttpDelete("{id}")]
        public async Task DeleteStore(int id)
        {
            await _storeRepository.DeleteStoreAsync(id);
        }

        //TEMP - TEST QUERY
        [HttpGet]
        public ActionResult<IList<Store>> TestQuery()
        {
            var storesWithoutEmployees = _storeRepository.GetAllStores();
            return Ok(storesWithoutEmployees);
        }


    }

}
