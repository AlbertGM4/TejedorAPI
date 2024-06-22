using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.CategoryDTO;
using Tejedor.Infrastructure.DTO.PromotionDTO;
using Tejedor.Infrastructure.DTO.UserDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.API.Controllers;

[ApiController]
//[Authorize]
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
    /// <param name="Authorization"></param>
    /// <returns></returns>
    [HttpGet("getUser")]
    public async Task<ActionResult<GetUserListDTO>> GetUser([FromHeader] string Authorization)
    {
        var getUser = await UserRepository.GetUser(Authorization);
        return getUser != null ? (GetUserListDTO)getUser : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="usersDtos"></param>
    [HttpPost("addUsers")]
    public async Task<IActionResult> AddUsers([FromBody] IEnumerable<SetUserListDTO> usersDtos)
    {
        var userEntities = usersDtos.Select(dto => (User)dto).ToList();
        await UserRepository.AddUsers(userEntities);
        return CreatedAtAction(nameof(GetAllUsers), null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userDto"></param>
    [HttpPost("addUser")]
    public async Task<IActionResult> AddUser([FromBody] SetUserListDTO userDto)
    {
        var userEntity = (User)userDto;
        await UserRepository.AddUser(userEntity);
        return CreatedAtAction(nameof(GetAllUsers), null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userID"></param>
    [HttpPut("updateUser")]
    public async Task<IActionResult> UpdateUser([FromHeader] string Authorization, [FromBody] SetUserListDTO updateUserDto)
    {
        // Encuentra el usuario en la base de datos
        var user = await UserRepository.GetUser(Authorization);

        if (user == null)
        {
            return NotFound();
        }

        // Actualiza los campos del usuario con los nuevos valores
        user.ProfileImageRoute = updateUserDto.ProfileImageRoute ?? user.ProfileImageRoute;
        user.UserName = updateUserDto.UserName ?? user.UserName;
        user.UserEmail = updateUserDto.UserEmail ?? user.UserEmail;
        user.Address = updateUserDto.Address ?? user.Address;
        user.BillingAddress = updateUserDto.BillingAddress ?? user.BillingAddress;
        user.Phone = updateUserDto.Phone ?? user.Phone;

        // Guarda los cambios en la base de datos
        var result = await UserRepository.UpdateUser(user);

        if (result)
        {
            return NoContent(); // 204 No Content
        }

        return StatusCode(500, "Un error ocurrió al actualizar el usuario");
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
