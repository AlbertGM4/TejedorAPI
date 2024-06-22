using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tejedor.API.Controllers;
using Tejedor.Infrastructure.DTO.OrderLineDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;
using Xunit;

namespace TejedorTest;

public class OrderLineTests
{
    private readonly Mock<IOrderLineRepository> _mockRepo;
    private readonly OrderLineController _controller;

    public OrderLineTests()
    {
        _mockRepo = new Mock<IOrderLineRepository>();
        _controller = new OrderLineController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllOrderLines_ReturnsOkResult_WithListOfOrderLines()
    {/*
        // Arrange
        var orderLines = new List<OrderLine>
        {
            new OrderLine { OrderLineID = 1, Qty = 1, Tax = 0.1f, Discount = 0.05f, SubTotal = 10, Total = 11, OrderID = 1, ProductID = 1 },
            new OrderLine { OrderLineID = 2, Qty = 2, Tax = 0.2f, Discount = 0.1f, SubTotal = 20, Total = 22, OrderID = 2, ProductID = 2 }
        };
        _mockRepo.Setup(repo => repo.GetOrderLines()).ReturnsAsync(orderLines);

        // Act
        var result = await _controller.GetAllOrderLines();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        */
    }

    [Fact]
    public async Task GetOrderLine_ReturnsNotFoundResult_WhenOrderLineDoesNotExist()
    {/*
        // Arrange
        _mockRepo.Setup(repo => repo.GetOrderLine(It.IsAny<int>())).ReturnsAsync((OrderLine)null);

        // Act
        var result = await _controller.GetOrderLine(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
        */
    }

    [Fact]
    public async Task AddOrderLines_ReturnsCreatedAtAction()
    {/*
        // Arrange
        var newOrderLine = new SetOrderLineListDTO { Qty = 1, Tax = 0.1f, Discount = 0.05f, SubTotal = 10, Total = 11, OrderID = 1, ProductID = 1 };
        var orderLines = new List<SetOrderLineListDTO> { newOrderLine };

        // Act
        var result = await _controller.AddOrderLines(orderLines);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
        */
    }

    // Similar tests can be written for UpdateOrderLines and DeleteOrderLines

}