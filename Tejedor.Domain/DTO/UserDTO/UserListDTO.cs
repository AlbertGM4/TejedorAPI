using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.UserDTO;

public class GetUserListDTO
{
    public required int UserID { get; set; }
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }

    public static explicit operator GetUserListDTO(User user)
    {
        return new GetUserListDTO()
        {
            UserID = user.UserID,
            UserName = user.UserName,
            UserEmail = user.UserEmail
        };
    }
}
public class SetUserListDTO
{
    public required int UserID { get; set; }
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }

    public static explicit operator User(SetUserListDTO user)
    {
        return new User()
        {
            UserID = user.UserID,
            UserName = user.UserName,
            UserEmail = user.UserEmail
        };
    }
}
