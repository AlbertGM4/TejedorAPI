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
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public string? Address { get; set; }
    public string? BillingAddress { get; set; }
    public string? Phone { get; set; }
    public int? Points { get; set; }


    public static explicit operator GetUserListDTO(User user)
    {
        return new GetUserListDTO()
        {
            UserName = user.UserName,
            UserEmail = user.UserEmail,
            Address = user.Address,
            BillingAddress = user.BillingAddress,
            Phone = user.Phone,
            Points = user.Points,
        };
    }
}
public class SetUserListDTO
{
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public string? Address { get; set; }
    public string? BillingAddress { get; set; }
    public string? Phone { get; set; }
    public int? Points { get; set; }

    public static explicit operator User(SetUserListDTO user)
    {
        return new User()
        {
            UserName = user.UserName,
            UserEmail = user.UserEmail,
            Address = user.Address,
            BillingAddress = user.BillingAddress,
            Phone = user.Phone,
            Points = user.Points,
        };
    }
}
