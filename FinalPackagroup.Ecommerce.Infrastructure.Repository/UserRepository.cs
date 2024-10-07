using Dapper;
using FinalPackagroup.Ecommerce.Domain.Entity;
using FinalPackagroup.Ecommerce.Infrastructure.Interface;
using FinalPackagroup.Ecommerce.Transversal.Common;
using System.Data;

namespace FinalPackagroup.Ecommerce.Infrastructure.Repository
{

    public class UserRepository : IUserRepository
    {
    
        private readonly IConnectionFactory _connection;

        public UserRepository(IConnectionFactory connectionFact)
        {
            _connection = connectionFact;
        }

        public User Authenticate(string userName, string password)
        {
            using (var conn = _connection.GetConnection)
            {
                var storeProcedure = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("Password", password);

                return conn.QuerySingle<User>(storeProcedure, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
