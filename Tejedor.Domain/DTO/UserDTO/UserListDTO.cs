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
    public string? ProfileImageRoute { get; set; }
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public string? Address { get; set; }
    public string? BillingAddress { get; set; }
    public string? Phone { get; set; }
    public int? ACoins { get; set; }


    public static explicit operator GetUserListDTO(User user)
    {
        return new GetUserListDTO()
        {
            UserID = user.UserID,
            ProfileImageRoute = user.ProfileImageRoute,
            UserName = user.UserName,
            UserEmail = user.UserEmail,
            Address = user.Address,
            BillingAddress = user.BillingAddress,
            Phone = user.Phone,
            ACoins = user.ACoins,
        };
    }
}
public class SetUserListDTO
{
    public string? ProfileImageRoute { get; set; }
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public string? Address { get; set; }
    public string? BillingAddress { get; set; }
    public string? Phone { get; set; }

    public static explicit operator User(SetUserListDTO user)
    {
        return new User()
        {
            ProfileImageRoute = user.ProfileImageRoute,
            UserName = user.UserName,
            UserEmail = user.UserEmail,
            Address = user.Address,
            BillingAddress = user.BillingAddress,
            Phone = user.Phone,
        };
    }
}
