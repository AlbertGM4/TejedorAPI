using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.Repository.Interfaces
{
    public interface IPromotionRepository
    {
        /// <summary>
        ///     It search for all the promotions in the database
        /// </summary>
        /// <returns> Returns an IEnumerable of all the promotions </returns>
        public Task<IEnumerable<Promotion>> GetPromotions();

        /// <summary>
        ///     It search for a promotion by the ID in the parameters
        /// </summary>
        /// <param name="promotionID"></param>
        /// <returns> Returns a promotion, if not, returns null </returns>
        public Task<Promotion?> GetPromotion(int promotionID);

        /// <summary>
        ///     It adds all the promotions in the IEnumerable that 
        ///     are in the database
        /// </summary>
        /// <param name="promotions"></param>
        /// <returns>  </returns>
        public Task AddPromotions(IEnumerable<Promotion> promotions);

        /// <summary>
        ///     It updates all the promotions in the IEnumerable that 
        ///     are in the database
        /// </summary>
        /// <param name="promotions"></param>
        /// <returns></returns>
        public Task UpdatePromotions(IEnumerable<Promotion> promotions);

        /// <summary>
        ///     It deletes all the promotions in the IEnumerable that 
        ///     are in the database
        /// </summary>
        /// <param name="promotions"></param>
        /// <returns></returns>
        public Task DeletePromotions(IEnumerable<Promotion> promotions);
    }
}
