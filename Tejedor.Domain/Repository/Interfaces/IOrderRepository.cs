using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.Repository.Interfaces;

public interface IOrderRepository
{
    /// <summary>
    ///     It search for all the orders in the database
    /// </summary>
    /// <returns> Return all the orders </returns>
    public Task<IEnumerable<Order>> GetOrders();

    /// <summary>
    ///     It search for a orders by the ID in the parameters
    /// </summary>
    /// <param name="orderID"> Id of the prodcut to search </param>
    /// <returns> Return the Order, if not, returns null </returns>
    public Task<Order?> GetOrder(int orderID);

    /// <summary>
    ///     It adds all the orders in the IEnumerable into the database
    /// </summary>
    /// <param name="orders"></param>
    public Task AddOrders(IEnumerable<Order> orders);

    /// <summary>
    ///     It updates all the orders in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="orders"></param>
    public Task UpdateOrders(IEnumerable<Order> orders);

    /// <summary>
    ///     It delete all the orders in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="orders"></param>
    public Task DeleteOrders(IEnumerable<Order> orders);
}
