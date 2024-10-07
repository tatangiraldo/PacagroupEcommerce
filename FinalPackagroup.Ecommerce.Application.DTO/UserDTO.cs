
using System.ComponentModel;

namespace FinalPackagroup.Ecommerce.Application.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        
        [DefaultValue("tatan")]
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [DefaultValue("123456")]
        public string Password { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
