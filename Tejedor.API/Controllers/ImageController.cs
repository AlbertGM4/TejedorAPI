using Microsoft.AspNetCore.Mvc;
using Tejedor.Infrastructure.DTO.ImageDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageRepository ImageRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="imageRepository"></param>
    public ImageController(IImageRepository imageRepository)
    {
        ImageRepository = imageRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("getImages")]
    public async Task<IEnumerable<GetImageListDTO>> GetAllImages()
    {
        return (await ImageRepository.GetImages()).Select(x => (GetImageListDTO) x);        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="imageID"></param>
    /// <returns></returns>
    [HttpGet("getImage/({imageID})")]
    public async Task<ActionResult<GetImageListDTO>> GetImage([FromRoute] int imageID)
    {
        var getImage = await ImageRepository.GetImage(imageID);
        return getImage != null ? (GetImageListDTO)getImage : NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="images"></param>
    [HttpPost("addImages")]
    public async Task AddImages(SetImageListDTO images)
    {
        await ImageRepository.AddImages(new List<Image>() { (Image) images } );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="images"></param>
    [HttpPut("updateImages")]
    public async Task UpdateImages(SetImageListDTO images)
    {
        await ImageRepository.UpdateImages(new List<Image>() { (Image) images });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="images"></param>
    [HttpDelete("deleteImages")]
    public async Task DeleteImages(SetImageListDTO images)
    {
        await ImageRepository.DeleteImages(new List<Image>() { (Image) images });
    }
}