using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.UserDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository UserRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRepository"></param>
    public UserController(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("getUsers")]
    public async Task<IEnumerable<GetUserListDTO>> GetAllUsers()
    {
        return (await UserRepository.GetUsers()).Select(x => (GetUserListDTO) x);        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    [HttpGet("getUser/({userID})")]
    public async Task<ActionResult<GetUserListDTO>> GetUser([FromRoute] int userID)
    {
        var getUser = await UserRepository.GetUser(userID);
        return getUser != null ? (GetUserListDTO)getUser : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="users"></param>
    [HttpPost("addUsers")]
    public async Task AddUsers(SetUserListDTO users)
    {
        await UserRepository.AddUsers(new List<User>() { (User) users } );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="users"></param>
    [HttpPut("updateUsers")]
    public async Task UpdateUsers(SetUserListDTO users)
    {
        await UserRepository.UpdateUsers(new List<User>() { (User) users });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="users"></param>
    [HttpDelete("deleteUsers")]
    public async Task DeleteUsers(SetUserListDTO users)
    {
        await UserRepository.DeleteUsers(new List<User>() { (User) users });
    }
}