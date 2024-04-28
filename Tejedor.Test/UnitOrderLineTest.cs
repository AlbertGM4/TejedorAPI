using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;
using Tejedor.Infrastructure.Entity;
using Tejedor.API.Controllers;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;
using Tejedor.Infrastructure.DTO.OrderLineDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TejedorTest;

public class OrderLineTest
{
    const int goodOrderLineID = 1;
    const int badOrderLineID = 2;

    public OrderLine MockOrderLine(int id)
    {
        return new OrderLine()
        {
            OrderLineID = id,
            ProductName = "MockOrderLineName",
            Qty = 10,
            UnitPrice = 5f,
            Tax = 21f,
            Discount = 0f,
            SubTotal = 100f,
            Total = 110f,
            OrderID = 10
        };
    }

    [Fact]
    public async Task GetOrderLineTest()
    {
        //Init vars
        Moq.Mock<IOrderLineRepository> IOrderLineRepositoryMock = new();

        OrderLine goodOrderLine = MockOrderLine(goodOrderLineID);
        OrderLine badProduct = MockOrderLine(badOrderLineID);

        // Good OrderLineID 
        IOrderLineRepositoryMock.Setup(x => x.GetOrderLine(goodOrderLineID)).Returns(async () => goodOrderLine);
        OrderLineController goodOrderLineController = new(IOrderLineRepositoryMock.Object);
        GetOrderLineListDTO goodReceivedProduct = (await goodOrderLineController.GetOrderLine(goodOrderLineID)).Value!;

        Assert.Equal(goodOrderLine.OrderLineID, goodReceivedProduct.OrderLineID);

        // Bad OrderLineID
        IOrderLineRepositoryMock.Setup(x => x.GetOrderLine(badOrderLineID)).Returns(async () => badProduct);
        OrderLineController badProductController = new(IOrderLineRepositoryMock.Object);
        GetOrderLineListDTO receivedProduct = (await badProductController.GetOrderLine(badOrderLineID)).Value!;

        Assert.Equal(badProduct.OrderLineID, receivedProduct.OrderLineID);
    }

    [Fact]
    public async Task NotGetOrderLineTest()
    {
        //Init vars
        Moq.Mock<IOrderLineRepository> IOrderLineRepositoryMock = new();

        // Not ProductID
        IOrderLineRepositoryMock.Setup(x => x.GetOrderLine(-1)).Returns(async() => null);

        OrderLineController notOrderLineController = new(IOrderLineRepositoryMock.Object);
        ActionResult<GetOrderLineListDTO> notReceivedOrderLine = (await notOrderLineController.GetOrderLine(-1));

        Assert.IsType<NotFoundResult>(notReceivedOrderLine.Result);
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