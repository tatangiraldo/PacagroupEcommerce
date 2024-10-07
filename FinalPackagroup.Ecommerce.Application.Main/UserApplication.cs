using FinalPackagroup.Ecommerce.Application.DTO;
using FinalPackagroup.Ecommerce.Application.Interface;
using FinalPackagroup.Ecommerce.Domain.Interface;
using FinalPackagroup.Ecommerce.Transversal.Common;
using FinalPackagroup.Ecommerce.Transversal.Mapper;
using System;

namespace FinalPackagroup.Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        public UserApplication(IUserDomain domain)
        {
            _userDomain = domain;
        }

        public Response<UserDTO>  Authenticate(string userName, string password)
        {
            var response = new Response<UserDTO>();

            if (userName == null || password == null)
            {
                response.Message = "Required information not sent";
            }

            try
            {
                var user = _userDomain.Authenticate(userName, password);
                if (user != null)
                {
                    response.Data = UserMapper.Map(user);
                    response.IsSuccess = true;
                }
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "User credentials were not found";
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
            }

            return response;
        }
    }
}
