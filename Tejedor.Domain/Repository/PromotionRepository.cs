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
    public class PromotionRepository : IPromotionRepository
    {
        private readonly TejedorDBContext _dbContext;

        public PromotionRepository(TejedorDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<IEnumerable<Promotion>> IPromotionRepository.GetPromotions()
        {
            return await _dbContext.Promotions.ToListAsync();
        }

        async Task<Promotion?> IPromotionRepository.GetPromotion(int promotionID)
        {
            return await _dbContext.Promotions.FirstOrDefaultAsync(p => p.PromotionID == promotionID);
        }

        async Task IPromotionRepository.AddPromotions(IEnumerable<Promotion> promotions)
        {
            _dbContext.Promotions.AddRange(promotions);
            await _dbContext.SaveChangesAsync();
        }

        async Task IPromotionRepository.UpdatePromotions(IEnumerable<Promotion> promotions)
        {
            _dbContext.Promotions.UpdateRange(promotions);
            await _dbContext.SaveChangesAsync();
        }

        async Task IPromotionRepository.DeletePromotions(IEnumerable<Promotion> promotions)
        {
            _dbContext.Promotions.RemoveRange(promotions);
            await _dbContext.SaveChangesAsync();
        }
    }
}
