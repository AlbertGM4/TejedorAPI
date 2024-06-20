using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;
using Tejedor.Infrastructure.Entity;
using Tejedor.API.Controllers;
using Tejedor.Infrastructure.Repository;
using Tejedor.Infrastructure.Repository.Interfaces;
using Tejedor.Infrastructure.DTO.OrderDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TejedorTest;

public class OrderTest
{
    const int goodOrderID = 1;
    const int badOrderID = 2;

    public Order MockOrder(int id)
    {
        return new Order()
        {
            OrderID = id,
            Created = DateTime.Now,
            CustomerID = 1
        };
    }

    [Fact]
    public async Task GetOrderTest()
    {
        //Init vars
        Moq.Mock<IOrderRepository> IOrderRepositoryMock = new();

        Order goodOrder = MockOrder(goodOrderID);
        Order badOrder = MockOrder(badOrderID);

        // Good ProductID 
        IOrderRepositoryMock.Setup(x => x.GetOrder(goodOrderID)).Returns(async () => goodOrder);
        OrderController goodOrderController = new(IOrderRepositoryMock.Object);
        GetOrderListDTO goodReceivedOrder = (await goodOrderController.GetOrder(goodOrderID)).Value!;

        Assert.Equal(goodOrder.OrderID, goodReceivedOrder.OrderID);

        // Bad ProductID
        IOrderRepositoryMock.Setup(x => x.GetOrder(badOrderID)).Returns(async () => badOrder);
        OrderController badOrderController = new(IOrderRepositoryMock.Object);
        GetOrderListDTO receivedOrder = (await badOrderController.GetOrder(badOrderID)).Value!;

        Assert.Equal(badOrder.OrderID, receivedOrder.OrderID);
    }

    [Fact]
    public async Task NotGetOrderTest()
    {
        //Init vars
        Moq.Mock<IOrderRepository> IOrderRepositoryMock = new();

        // Not ProductID
        IOrderRepositoryMock.Setup(x => x.GetOrder(-1)).Returns(async() => null);

        OrderController notOrderController = new(IOrderRepositoryMock.Object);
        ActionResult<GetOrderListDTO> notReceivedOrder = (await notOrderController.GetOrder(-1));

        Assert.IsType<NotFoundResult>(notReceivedOrder.Result);
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