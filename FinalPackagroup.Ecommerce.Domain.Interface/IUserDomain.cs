using FinalPackagroup.Ecommerce.Domain.Entity;

namespace FinalPackagroup.Ecommerce.Domain.Interface
{
    public interface IUserDomain
    {
        User Authenticate (string username, string password);
    }
}
