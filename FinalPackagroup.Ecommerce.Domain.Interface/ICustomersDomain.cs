using FinalPackagroup.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalPackagroup.Ecommerce.Domain.Interface
{
    public interface ICustomersDomain
    {
        #region  SYNC METHODS
        bool Insert(Customers customer);

        bool Update(Customers customer);

        bool Delete(string customerId);

        Customers Get(string customerId);

        IEnumerable<Customers> GetAll();
        #endregion

        #region ASYNC METHODS
        Task<bool> InsertAsync(Customers customer);

        Task<bool> UpdateAsync(Customers customer);

        Task<bool> DeleteAsync(string customerId);

        Task<Customers> GetAsync(string customerId);

        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}

