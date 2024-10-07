using FinalPackagroup.Ecommerce.Domain.Entity;

namespace FinalPackagroup.Ecommerce.Infrastructure.Interface
{
    public interface IUserRepository
    {
        User Authenticate(string userName, string password);
    }
}
