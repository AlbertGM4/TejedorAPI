using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;
using Tejedor.Infrastructure.Entity;
using Tejedor.API.Controllers;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;
using Tejedor.Infrastructure.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TejedorTest;

public class ProductTest
{
    const int goodProductID = 1;
    const int badProductID = 2;

    public Product MockProduct(int id)
    {
        return new Product()
        {
            ProductID = id,
            Name = "MockProductName",
            Price = 10.00m,
            CategoryID = 1
        };
    }

    [Fact]
    public async Task GetProductTest()
    {
        //Init vars
        Moq.Mock<IProductRepository> IProductRepositoryMock = new();

        Product goodProduct = MockProduct(goodProductID);
        Product badProduct = MockProduct(badProductID);

        // Good ProductID 
        IProductRepositoryMock.Setup(x => x.GetProduct(goodProductID)).Returns(async () => goodProduct);
        ProductController goodProductController = new(IProductRepositoryMock.Object);
        GetProductListDTO goodReceivedProduct = (await goodProductController.GetProduct(goodProductID)).Value!;

        Assert.Equal(goodProduct.ProductID, goodReceivedProduct.ProductID);

        // Bad ProductID
        IProductRepositoryMock.Setup(x => x.GetProduct(badProductID)).Returns(async () => badProduct);
        ProductController badProductController = new(IProductRepositoryMock.Object);
        GetProductListDTO receivedProduct = (await badProductController.GetProduct(badProductID)).Value!;

        Assert.Equal(badProduct.ProductID, receivedProduct.ProductID);
    }

    [Fact]
    public async Task NotGetProductTest()
    {
        //Init vars
        Moq.Mock<IProductRepository> IProductRepositoryMock = new();

        // Not ProductID
        IProductRepositoryMock.Setup(x => x.GetProduct(-1)).Returns(async() => null);

        ProductController notProductController = new(IProductRepositoryMock.Object);
        ActionResult<GetProductListDTO> notReceivedProduct = (await notProductController.GetProduct(-1));

        Assert.IsType<NotFoundResult>(notReceivedProduct.Result);
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