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
using Tejedor.Infrastructure.DTO.UserDTO;

namespace TejedorTest;

public class UserTests
{
    private readonly Mock<IUserRepository> _mockRepo;
    private readonly UserController _controller;

    public UserTests()
    {
        _mockRepo = new Mock<IUserRepository>();
        _controller = new UserController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOkResult_WithListOfUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { UserID = 1, UserName = "John", UserEmail = "john@example.com" },
            new User { UserID = 2, UserName = "Jane", UserEmail = "jane@example.com" }
        };
        _mockRepo.Setup(repo => repo.GetUsers()).ReturnsAsync(users);

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetUser_ReturnsNotFoundResult_WhenUserDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.GetUser(It.IsAny<int>())).ReturnsAsync((User)null);

        // Act
        var result = await _controller.GetUser(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task AddUsers_ReturnsCreatedAtAction()
    {
        // Arrange
        var newUser = new SetUserListDTO { UserName = "Doe", UserEmail = "doe@example.com" };
        var users = new List<SetUserListDTO> { newUser };

        // Act
        var result = await _controller.AddUsers(users);

        // Assert
        _mockRepo.Verify(repo => repo.AddUsers(It.IsAny<IEnumerable<User>>()), Times.Once);
        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public async Task UpdateUsers_ReturnsNoContent()
    {
        // Arrange
        var updatedUser = new SetUserListDTO { UserName = "John Updated", UserEmail = "john_updated@example.com" };

        // Act
        var result = await _controller.UpdateUsers(new List<SetUserListDTO> { updatedUser });

        // Assert
        _mockRepo.Verify(repo => repo.UpdateUsers(It.IsAny<IEnumerable<User>>()), Times.Once);
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteUsers_ReturnsNoContent()
    {
        // Arrange
        var userToDelete = new SetUserListDTO { UserName = "John", UserEmail = "john@example.com" };

        // Act
        var result = await _controller.DeleteUsers(new List<SetUserListDTO> { userToDelete });

        // Assert
        _mockRepo.Verify(repo => repo.DeleteUsers(It.IsAny<IEnumerable<User>>()), Times.Once);
        Assert.IsType<NoContentResult>(result);
    }

}