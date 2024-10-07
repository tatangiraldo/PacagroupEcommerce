using FinalPackagroup.Ecommerce.Application.DTO;
using FinalPackagroup.Ecommerce.Transversal.Common;

namespace FinalPackagroup.Ecommerce.Application.Interface
{
    public  interface IUserApplication
    {
        Response<UserDTO> Authenticate(string userName, string password);
    }
}
