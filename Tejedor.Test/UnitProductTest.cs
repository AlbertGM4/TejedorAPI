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
using Moq;

namespace TejedorTest;

public class ProductTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly ProductController _controller;

    public ProductTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        _controller = new ProductController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllProducts_ReturnsOkResult_WithListOfProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product { ProductID = 1, Name = "Product1", Price = 10, Stock = 100, CategoryID = 1 },
            new Product { ProductID = 2, Name = "Product2", Price = 20, Stock = 200, CategoryID = 2 }
        };
        _mockRepo.Setup(repo => repo.GetProducts()).ReturnsAsync(products);

        // Act
        var result = await _controller.GetAllProducts();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetProduct_ReturnsNotFoundResult_WhenProductDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.GetProduct(It.IsAny<int>())).ReturnsAsync((Product)null);

        // Act
        var result = await _controller.GetProduct(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task AddProducts_ReturnsCreatedAtAction()
    {
        // Arrange
        var newProduct = new SetProductListDTO { Name = "NewProduct", Price = 10, Stock = 100, CategoryID = 1 };
        var products = new List<SetProductListDTO> { newProduct };

        // Act
        var result = await _controller.AddProducts(products);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }

    // Similar tests can be written for UpdateProducts and DeleteProducts
    /// <summary>
    /// /////////
    /// </summary>
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