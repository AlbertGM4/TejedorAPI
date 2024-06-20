using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.PromotionDTO;
using Tejedor.Infrastructure.DTO.UserDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository;
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
    /// <param name="usersDtos"></param>
    [HttpPost("addUsers")]
    public async Task<IActionResult> AddUsers([FromBody] IEnumerable<SetUserListDTO> usersDtos)
    {
        var userEntities = usersDtos.Select(dto => (User)dto).ToList(); ;
        await UserRepository.AddUsers(userEntities);
        return CreatedAtAction(nameof(GetAllUsers), null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="users"></param>
    [HttpPut("updateUsers")]
    public async Task<IActionResult> UpdateUsers([FromBody] IEnumerable<SetUserListDTO> users)
    {
        var userEntities = users.Select(x => (User)x);
        await UserRepository.UpdateUsers(userEntities);
        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="users"></param>
    [HttpDelete("deleteUsers")]
    public async Task<IActionResult> DeleteUsers([FromBody] IEnumerable<SetUserListDTO> users)
    {
        var userEntities = users.Select(x => (User)x);
        await UserRepository.DeleteUsers(userEntities);
        return NoContent();
    }

}
