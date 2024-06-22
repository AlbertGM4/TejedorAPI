using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.Repository.Interfaces;

public interface IUserRepository
{
    /// <summary>
    ///     It search for all the users in the database
    /// </summary>
    /// <returns> Return all the products </returns>
    public Task<IEnumerable<User>> GetUsers();

    /// <summary>
    ///     It search for a user by the ID in the parameters
    /// </summary>
    /// <param name="userName"> Id of the prodcut to search </param>
    /// <returns> Return the Product, if not, returns null </returns>
    public Task<User?> GetUser(string userName);

    /// <summary>
    ///     It search for a user by the ID in the parameters
    /// </summary>
    /// <param name="userID"> Id of the prodcut to search </param>
    /// <returns> Return the Product, if not, returns null </returns>
    public Task<User?> GetUser(int userID);

    /// <summary>
    ///     It adds all the users in the IEnumerable into the database
    /// </summary>
    /// <param name="users"></param>
    public Task AddUsers(IEnumerable<User> users);

    /// <summary>
    ///     It adds all the users in the IEnumerable into the database
    /// </summary>
    /// <param name="users"></param>
    public Task AddUser(User users);

    /// <summary>
    ///     It updates all the users in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="user"></param>
    public Task<bool> UpdateUser(User user);

    /// <summary>
    ///     It updates all the users in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="users"></param>
    public Task UpdateUsers(IEnumerable<User> users);

    /// <summary>
    ///     It delete all the users in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="users"></param>
    public Task DeleteUsers(IEnumerable<User> users);

    /// <summary>
    ///     It delete all the users in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="username"></param>
    /// <param name="userpassword"></param>
    public Task<User?> LoginUser(string username, string userpassword);

    /// <summary>
    ///     It delete all the users in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="username"></param>
    /// <param name="userpassword"></param>
    /// <param name="userEmail"></param>
    /// <param name="userAddress"></param>
    /// <param name="userBillingAddress"></param>
    /// <param name="userPhone"></param>
    public Task<User?> RegisterUser(string username, string userpassword, string userEmail, 
        string userAddress, string userBillingAddress, string userPhone);

}
