using FinalPackagroup.Ecommerce.Application.DTO;
using FinalPackagroup.Ecommerce.Domain.Entity;


namespace FinalPackagroup.Ecommerce.Transversal.Mapper
{
    public class UserMapper
    {
        public static UserDTO Map(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Token = user.Token,
            };
        }

        public static User Map(UserDTO dto)
        {
            return new User
            {
                UserId = dto.UserId,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                Token = dto.Token,
            };
        }
    }
}
