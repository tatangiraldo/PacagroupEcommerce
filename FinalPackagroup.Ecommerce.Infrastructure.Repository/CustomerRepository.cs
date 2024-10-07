using Dapper;
using FinalPackagroup.Ecommerce.Domain.Entity;
using FinalPackagroup.Ecommerce.Infrastructure.Interface;
using FinalPackagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FinalPackagroup.Ecommerce.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region SYNC
        public bool Insert(Customers c)
        {
            if (c == null) return false;

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var p = new DynamicParameters();
                p = FillCustomerProperties(ref p, c);
                var result = connection.Execute(query, param: p, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customers c)
        {
            if (c == null) return false;

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                DynamicParameters p = new DynamicParameters();
                FillCustomerProperties(ref p, c);

                var result = connection.Execute(query, param: p, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(string? customerId)
        {
            if (customerId == null) { return false; }

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var p = new DynamicParameters();
                p.Add("CutomerID", customerId);
                var result = connection.Execute(query, param: p, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customers Get(string customerId)
        {
            if (customerId == null || customerId.Length == 0) return null;

            using (var conn = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetById";
                var p = new DynamicParameters();
                p.Add("CustomerID", customerId);

                Customers result = conn.QuerySingle<Customers>(query, param: p, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";

                var customerList = conn.Query<Customers>(query, commandType: CommandType.StoredProcedure);
                return customerList;
            }
        }


        #endregion

        /**************************************************************/
        #region ASYNC
        public async Task<bool> InsertAsync(Customers customer)
        {
            if (customer == null) return false;
            using (var conn = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                DynamicParameters p = new DynamicParameters();
                p = FillCustomerProperties(ref p, customer);

                var result = await conn.ExecuteAsync(query, param: p, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customers customer)
        {
            if (customer == null) return false;
            using (var conn = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                DynamicParameters p = new DynamicParameters();
                p = FillCustomerProperties(ref p, customer);

                var result = await conn.ExecuteAsync(query, param: p, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            if (customerId == null) { return false; }

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var p = new DynamicParameters();
                p.Add("CutomerID", customerId);

                var result = await connection.ExecuteAsync(query, param: p, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            if (customerId == null || customerId.Length == 0) return null;

            using (var conn = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetById";
                var p = new DynamicParameters();
                p.Add("CustomerID", customerId);

                var result = await conn.QuerySingleAsync<Customers>(query, param: p, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";

                var customerList = await conn.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return customerList;
            }
        }

        #endregion

        #region FILL PROPERTIES
        public DynamicParameters FillCustomerProperties(ref DynamicParameters parameteres, Customers customer)
        {
            parameteres.Add("CustomerID", customer.CustomerID);
            parameteres.Add("CompanyName", customer.CompanyName);
            parameteres.Add("ContactName", customer.ContactName);
            parameteres.Add("ContactTitle", customer.ContactTitle);
            parameteres.Add("Address", customer.Address);
            parameteres.Add("City", customer.City);
            parameteres.Add("Region", customer.Region);
            parameteres.Add("PostalCode", customer.PostalCode);
            parameteres.Add("Country", customer.Country);
            parameteres.Add("Phone", customer.Phone);
            parameteres.Add("Fax", customer.Fax);

            return parameteres;
        }

        #endregion
    }
}
