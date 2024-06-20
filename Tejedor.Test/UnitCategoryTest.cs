using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;
using Tejedor.Infrastructure.Entity;
using Tejedor.API.Controllers;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;
using Tejedor.Infrastructure.DTO.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TejedorTest;

public class CategoryTest
{
    const int goodCategoryID = 1;
    const int badCategoryID = 2;

    public Category MockCategory(int id)
    {
        return new Category()
        {
            CategoryID = id,
            Name = "MockCategoryName",
            Description = "This is a description",
            ImagesRoute = "/testeoCategory"
        };
    }

    [Fact]
    public async Task GetCategoryTest()
    {
        //Init vars
        Moq.Mock<ICategoryRepository> ICategoryRepositoryMock = new();

        Category goodCategory = MockCategory(goodCategoryID);
        Category badCategory = MockCategory(badCategoryID);

        // Good CategoryID 
        ICategoryRepositoryMock.Setup(x => x.GetCategory(goodCategoryID)).Returns(async () => goodCategory);
        CategoryController goodCategoryController = new(ICategoryRepositoryMock.Object);
        GetCategoryListDTO goodReceivedCategory = (await goodCategoryController.GetCategory(goodCategoryID)).Value!;

        Assert.Equal(goodCategory.CategoryID, goodReceivedCategory.CategoryID);

        // Bad CategoryID
        ICategoryRepositoryMock.Setup(x => x.GetCategory(badCategoryID)).Returns(async () => badCategory);
        CategoryController badCategoryController = new(ICategoryRepositoryMock.Object);
        GetCategoryListDTO receivedCategory = (await badCategoryController.GetCategory(badCategoryID)).Value!;

        Assert.Equal(badCategory.CategoryID, receivedCategory.CategoryID);
    }

    [Fact]
    public async Task NotGetCategoryTest()
    {
        //Init vars
        Moq.Mock<ICategoryRepository> ICategoryRepositoryMock = new();

        // Not CategoryID
        ICategoryRepositoryMock.Setup(x => x.GetCategory(-1)).Returns(async() => null);

        CategoryController notCategoryController = new(ICategoryRepositoryMock.Object);
        ActionResult<GetCategoryListDTO> notReceivedCategory = (await notCategoryController.GetCategory(-1));

        Assert.IsType<NotFoundResult>(notReceivedCategory.Result);
    }


    [Fact]
    public void GetCategory()
    {
        //IDCategory positivo / IDCategory negativo
    }

}