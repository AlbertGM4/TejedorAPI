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
    public class ImageRepository : IImageRepository
    {
        private readonly TejedorDBContext _dbContext;
        public ImageRepository(TejedorDBContext context) 
        {
            _dbContext = context;
        }

        async Task<IEnumerable<Image>> IImageRepository.GetImages()
        {
            return _dbContext.Images;
        }

        async Task<Image?> IImageRepository.GetImage(int imageID)
        {
            return await _dbContext.Images.FirstOrDefaultAsync(x => x.ImageID == imageID);
        }

        async Task IImageRepository.AddImages(IEnumerable<Image> images)
        {
            _dbContext.Images.AddRange(images);
            await _dbContext.SaveChangesAsync();
        }

        async Task IImageRepository.UpdateImages(IEnumerable<Image> images)
        {
            throw new NotImplementedException();
        }

        async Task IImageRepository.DeleteImages(IEnumerable<Image> images)
        {
            throw new NotImplementedException();
        }
    }
}
