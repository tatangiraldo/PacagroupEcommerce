using FinalPackagroup.Ecommerce.Application.DTO;
using FinalPackagroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalPackagroup.Ecommerce.Application.Interface
{
    public interface IcustomerApplication
    {
        #region  SYNC METHODS
        Response<bool> Insert(CustomersDTO customer);

        Response<bool> Update(CustomersDTO customer);

        Response<bool> Delete(string customerId);

        Response<CustomersDTO> Get(string customerId);

        Response<IEnumerable<CustomersDTO>> GetAll();
        #endregion

        #region ASYNC METHODS
        Task<Response<bool>> InsertAsync(CustomersDTO customer);

        Task<Response<bool>> UpdateAsync(CustomersDTO customer);

        Task<Response<bool>> DeleteAsync(string customerId);

        Task<Response<CustomersDTO>> GetAsync(string customerId);

        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
        #endregion
    }
}
