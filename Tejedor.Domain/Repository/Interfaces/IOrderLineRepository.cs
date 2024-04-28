using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.Repository.Interfaces;

public interface IOrderLineRepository
{
    /// <summary>
    ///     It search for all the order lines in the database
    /// </summary>
    /// <returns> Return all the products </returns>
    public Task<IEnumerable<OrderLine>> GetOrderLines();

    /// <summary>
    ///     It search for a order line by the ID in the parameters
    /// </summary>
    /// <param name="orderLineID"> Id of the prodcut to search </param>
    /// <returns> Return the Product, if not, returns null </returns>
    public Task<OrderLine?> GetOrderLine(int orderLineID);

    /// <summary>
    ///     It adds all the order lines in the IEnumerable into 
    ///     the database
    /// </summary>
    /// <param name="orderLines"></param>
    public Task AddOrderLines(IEnumerable<OrderLine> orderLines);

    /// <summary>
    ///     It updates all the orderLines in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="orderLines"></param>
    public Task UpdateOrderLines(IEnumerable<OrderLine> orderLines);

    /// <summary>
    ///     It delete all the orderLines in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="orderLines"></param>
    public Task DeleteOrderLines(IEnumerable<OrderLine> orderLines);
}
