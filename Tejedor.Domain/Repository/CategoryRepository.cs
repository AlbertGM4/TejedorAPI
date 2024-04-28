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
    public class CategorytRepository : ICategoryRepository
    {
        private readonly TejedorDBContext _dbContext;
        public CategorytRepository(TejedorDBContext context) 
        {
            _dbContext = context;
        }

        async Task<IEnumerable<Category>> ICategoryRepository.GetCategories()
        {
            return _dbContext.Categories;
        }

        async Task<Category?> ICategoryRepository.GetCategory(int categoryID)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryID == categoryID);
        }

        async Task ICategoryRepository.AddCategories(IEnumerable<Category> categories)
        {
            _dbContext.Categories.AddRange(categories);
            await _dbContext.SaveChangesAsync();
        }

        async Task ICategoryRepository.UpdateCategories(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }

        async Task ICategoryRepository.DeleteCategories(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }
    }
}
