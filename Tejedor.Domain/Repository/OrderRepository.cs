using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TejedorDBContext _dbContext;
        public OrderRepository(TejedorDBContext context) 
        {
            _dbContext = context;
        }

        async Task<IEnumerable<Order>> IOrderRepository.GetOrders()
        {
            return await _dbContext.Orders.ToListAsync(); ;
        }

        async Task<Order?> IOrderRepository.GetOrder(int orderID)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(order_id => order_id.OrderID == orderID);
        }

        async Task IOrderRepository.AddOrders(IEnumerable<Order> orders)
        {
            _dbContext.Orders.AddRange(orders);
            await _dbContext.SaveChangesAsync();
        }

        async Task IOrderRepository.AddOrder(Order order)
        {
            _dbContext.Orders.AddRange(order);
            await _dbContext.SaveChangesAsync();
        }

        async Task IOrderRepository.UpdateOrders(IEnumerable<Order> orders)
        {
            _dbContext.Orders.UpdateRange(orders);
            await _dbContext.SaveChangesAsync();
        }

        async Task IOrderRepository.DeleteOrders(IEnumerable<Order> orders)
        {
            _dbContext.Orders.RemoveRange(orders);
            await _dbContext.SaveChangesAsync();
        }
    }
}
