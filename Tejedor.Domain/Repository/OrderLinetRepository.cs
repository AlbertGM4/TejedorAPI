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
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly TejedorDBContext _dbContext;
        public OrderLineRepository(TejedorDBContext context) 
        {
            _dbContext = context;
        }

        async Task<IEnumerable<OrderLine>> IOrderLineRepository.GetOrderLines()
        {
            return _dbContext.OrderLines;
        }

        async Task<OrderLine?> IOrderLineRepository.GetOrderLine(int orderLineID)
        {
            return await _dbContext.OrderLines.FirstOrDefaultAsync(x => x.OrderLineID == orderLineID);
        }

        async Task IOrderLineRepository.AddOrderLines(IEnumerable<OrderLine> orderLines)
        {
            _dbContext.OrderLines.AddRange(orderLines);
            await _dbContext.SaveChangesAsync();
        }

        async Task IOrderLineRepository.UpdateOrderLines(IEnumerable<OrderLine> orderLines)
        {
            throw new NotImplementedException();
        }

        async Task IOrderLineRepository.DeleteOrderLines(IEnumerable<OrderLine> orderLines)
        {
            throw new NotImplementedException();
        }
    }
}
