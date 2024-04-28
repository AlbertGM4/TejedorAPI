using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        /// <summary>
        ///     It search for all the categories in the database
        /// </summary>
        /// <returns> Returns an IEnumerable of all the categories </returns>
        public Task<IEnumerable<Category>> GetCategories();

        /// <summary>
        ///     It search for a category by the ID in the parameters
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns> Returns a category, if not, returns null </returns>
        public Task<Category?> GetCategory(int categoryID);

        /// <summary>
        ///     It adds all the categories in the IEnumerable that 
        ///     are in the database
        /// </summary>
        /// <param name="categories"></param>
        /// <returns>  </returns>
        public Task AddCategories(IEnumerable<Category> categories);

        /// <summary>
        ///     It updates all the categories in the IEnumerable that 
        ///     are in the database
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public Task UpdateCategories(IEnumerable<Category> categories);

        /// <summary>
        ///     It deletes all the categories in the IEnumerable that 
        ///     are in the database
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public Task DeleteCategories(IEnumerable<Category> categories);
    }
}
