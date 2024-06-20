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
using Moq;
using Tejedor.Infrastructure.DTO.PromotionDTO;

namespace TejedorTest;

public class PromotionTests
{
    private readonly Mock<IPromotionRepository> _mockRepo;
    private readonly PromotionController _controller;

    public PromotionTests()
    {
        _mockRepo = new Mock<IPromotionRepository>();
        _controller = new PromotionController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllPromotions_ReturnsOkResult_WithListOfPromotions()
    {
        // Arrange
        var promotions = new List<Promotion>
        {
            new Promotion { PromotionID = 1, Code = 123, Discount = 10, ExpirationDate = DateTime.Now.AddMonths(1), MaxUses = 100, UsesCount = 10 },
            new Promotion { PromotionID = 2, Code = 456, Discount = 20, ExpirationDate = DateTime.Now.AddMonths(2), MaxUses = 200, UsesCount = 20 }
        };
        _mockRepo.Setup(repo => repo.GetPromotions()).ReturnsAsync(promotions);

        // Act
        var result = await _controller.GetAllPromotions();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetPromotion_ReturnsNotFoundResult_WhenPromotionDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.GetPromotion(It.IsAny<int>())).ReturnsAsync((Promotion)null);

        // Act
        var result = await _controller.GetPromotion(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task AddPromotions_ReturnsCreatedAtAction()
    {
        // Arrange
        var newPromotion = new SetPromotionListDTO { Code = 789, Discount = 15, ExpirationDate = DateTime.Now.AddMonths(3), MaxUses = 150, UsesCount = 0 };
        var promotions = new List<SetPromotionListDTO> { newPromotion };

        // Act
        var result = await _controller.AddPromotions(promotions);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }

    // Similar tests can be written for UpdatePromotions and DeletePromotions

}