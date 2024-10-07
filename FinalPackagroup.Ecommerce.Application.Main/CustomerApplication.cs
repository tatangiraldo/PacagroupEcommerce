using FinalPackagroup.Ecommerce.Application.DTO;
using FinalPackagroup.Ecommerce.Application.Interface;
using FinalPackagroup.Ecommerce.Domain.Interface;
using FinalPackagroup.Ecommerce.Transversal.Common;
using FinalPackagroup.Ecommerce.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FinalPackagroup.Ecommerce.Application.Main
{
    public class CustomerApplication : IcustomerApplication
    {
        private readonly ICustomersDomain _domain;
        //private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;

        public CustomerApplication(
                                ICustomersDomain domain,
                                IAppLogger<CustomerApplication> logger
                                /*, IMapper mapper*/)
        {
            _domain = domain;
            //_mapper = mapper;
            _logger = logger;
        }

        #region  SYNC METHODS
        public Response<bool> Insert(CustomersDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = CustomerMapper.Map(customerDTO);
                response.Data = _domain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<bool> Update(CustomersDTO customerDTO)
        {

            var result = new Response<bool>();
            try
            {
                var customer = CustomerMapper.Map(customerDTO);
                result.Data = _domain.Update(customer);
                if (result.Data)
                {
                    result.IsSuccess = true;
                    result.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public Response<bool> Delete(string customerId)
        {

            var response = new Response<bool>();
            try
            {
                response.Data = _domain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess= true;
                    response.Message = "Success";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }

            return response;
        }

        public Response<CustomersDTO> Get(string customerId)
        {

            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _domain.Get(customerId);
                response.Data = CustomerMapper.Map(customer);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }

            return response;
        }

        public Response<IEnumerable<CustomersDTO>> GetAll()
        {

            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var CustomerList = new List<CustomersDTO>();

                var customers = _domain.GetAll();
                if (customers?.Count() > 0)
                {
                    foreach (var c in customers)
                    {
                        CustomerList.Add(CustomerMapper.Map(c));
                    }
                }

                response.Data = CustomerList;

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Query Success");
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
                _logger.LogError(Ex.Message);
            }

            return response;

        }
        #endregion

        #region ASYNC METHODS
        public async Task<Response<bool>> InsertAsync(CustomersDTO customer)
        {

            var result = new Response<bool>();
            try
            {
                result.Data = await _domain.InsertAsync(CustomerMapper.Map(customer));
                if (result.Data)
                {
                    result.IsSuccess= true;
                    result.Message = "Great!";
                }

            }
            catch (Exception Ex)
            {
                result.Message = Ex.Message;
            }
            return result;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDTO customer)
        {

            var result = new Response<bool>();
            try
            {
                result.Data = await _domain.UpdateAsync(CustomerMapper.Map(customer));
                if (result.Data)
                {
                    result.IsSuccess= true;
                    result.Message = "Great!";
                }
            }
            catch (Exception Ex)
            {
                result.Message = Ex.Message;
            }

            return result;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var result = new Response<bool>();
            try
            {
                result.Data = await _domain.DeleteAsync(customerId);
                if (result.Data)
                {
                    result.IsSuccess= true;
                    result.Message = "Great!";
                }
            }
            catch (Exception Ex)
            {
                result.Message = Ex.Message;
            }

            return result;
        }

        public async Task<Response<CustomersDTO>> GetAsync(string customerId)
        {

            var result = new Response<CustomersDTO>();
            try
            {
                result.Data = CustomerMapper.Map(await _domain.GetAsync(customerId));
                if (result.Data != null)
                {
                    result.IsSuccess= true;
                    result.Message = "Great!";
                }
            }
            catch (Exception Ex)
            {
                result.Message = Ex.Message;
            }

            return result;
        }

        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {

            var result = new Response<IEnumerable<CustomersDTO>>();
            result.Message = "No data";

            try
            {
                var CustomerList = new List<CustomersDTO>();

                var getCustomers = await _domain.GetAllAsync();
                if (getCustomers?.Count() > 0)
                {
                    foreach (var custom in getCustomers)
                    {
                        CustomerList.Add(CustomerMapper.Map(custom));
                    }

                    result.Data = CustomerList;
                    result.Message = "Great!";
                    result.IsSuccess= true;
                }
            }
            catch (Exception Ex)
            {
                result.Message = Ex.Message;
            }

            return result;
        }
        #endregion
    }
}
