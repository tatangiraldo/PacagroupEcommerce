using FinalPackagroup.Ecommerce.Domain.Entity;
using FinalPackagroup.Ecommerce.Domain.Interface;
using FinalPackagroup.Ecommerce.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalPackagroup.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly ICustomerRepository _repo;

        #region Sync
        public CustomersDomain(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public bool Insert(Customers customer)
        {
            return _repo.Insert(customer);
        }

        public bool Update(Customers customer)
        {
            return _repo.Update(customer);
        }

        public bool Delete(string customerId)
        {
            return _repo.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _repo.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _repo.GetAll();
        }
        #endregion


        #region Async
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _repo.GetAsync(customerId);
        }

        public async Task<bool> InsertAsync(Customers customer)
        {
            return await _repo.InsertAsync(customer);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _repo.DeleteAsync(customerId);
        }
        public async Task<bool> UpdateAsync(Customers customer)
        {
            return await _repo.UpdateAsync(customer);
        }
        #endregion
    }
}
