using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;
using Tejedor.Infrastructure.Entity;
using Tejedor.API.Controllers;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;
using Tejedor.Infrastructure.DTO.ImageDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Image = Tejedor.Infrastructure.Entity.Image;

namespace TejedorTest;

public class ImageTest
{
    const int goodImageID = 1;
    const int badImageID = 2;

    public Image MockImage(int id)
    {
        return new Image()
        {
            ImageID = id,
            ProductID = 1
        };
    }

    [Fact]
    public async Task GetImageTest()
    {
        //Init vars
        Moq.Mock<IImageRepository> IImageRepositoryMock = new();

        Image goodImage = MockImage(goodImageID);
        Image badImage = MockImage(badImageID);

        // Good ProductID 
        IImageRepositoryMock.Setup(x => x.GetImage(goodImageID)).Returns(async () => goodImage);
        ImageController goodImageController = new(IImageRepositoryMock.Object);
        GetImageListDTO goodReceivedImage = (await goodImageController.GetImage(goodImageID)).Value!;

        Assert.Equal(goodImage.ProductID, goodReceivedImage.ProductID);

        // Bad ProductID
        IImageRepositoryMock.Setup(x => x.GetImage(badImageID)).Returns(async () => badImage);
        ImageController badImageController = new(IImageRepositoryMock.Object);
        GetImageListDTO receivedImage = (await badImageController.GetImage(badImageID)).Value!;

        Assert.Equal(badImage.ProductID, receivedImage.ProductID);
    }

    [Fact]
    public async Task NotGetImageTest()
    {
        //Init vars
        Moq.Mock<IImageRepository> IImageRepositoryMock = new();

        // Not ProductID
        IImageRepositoryMock.Setup(x => x.GetImage(-1)).Returns(async() => null);

        ImageController notProductController = new(IImageRepositoryMock.Object);
        ActionResult<GetImageListDTO> notReceivedImage = (await notProductController.GetImage(-1));

        Assert.IsType<NotFoundResult>(notReceivedImage.Result);
    }

    [Fact]
    public void GetPrice()
    {
        //Precio positivo / precio negativo
    }

    [Fact]
    public void GetCategory()
    {
        //IDCategory positivo / IDCategory negativo
    }

}