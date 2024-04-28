using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.Repository.Interfaces;

public interface IImageRepository
{
    /// <summary>
    ///     It search for all the images in the database
    /// </summary>
    /// <returns> Return all the images </returns>
    public Task<IEnumerable<Image>> GetImages();

    /// <summary>
    ///     It search for a image by the ID in the parameters
    /// </summary>
    /// <param name="imageID"> Id of the image to search </param>
    /// <returns> Return the Image, if not, returns null </returns>
    public Task<Image?> GetImage(int imageID);

    /// <summary>
    ///     It adds all the images in the IEnumerable into the database
    /// </summary>
    /// <param name="images"></param>
    public Task AddImages(IEnumerable<Image> images);

    /// <summary>
    ///     It updates all the images in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="images"></param>
    public Task UpdateImages(IEnumerable<Image> images);

    /// <summary>
    ///     It delete all the images in the IEnumerable that 
    ///     are in the database
    /// </summary>
    /// <param name="images"></param>
    public Task DeleteImages(IEnumerable<Image> images);
}
