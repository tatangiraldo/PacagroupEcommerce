using System;
using FinalPackagroup.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FinalPackagroup.Ecommerce.Infastructure.Data
{
    public class ConnectionFactory : IConnectionFactory 
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _configuration.GetConnectionString("connDB");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
