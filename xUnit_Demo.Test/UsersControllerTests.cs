using Microsoft.AspNetCore.Mvc;
using Moq;
using Tynamix.ObjectFiller;
using xUnit_Demo.Controllers;
using xUnit_Demo.Models;
using xUnit_Demo.Services.Users;

namespace xUnit_Demo.Test;

public class UsersControllerTests
{
    [Fact]
    public async Task GetAllUsers_ReturnsOkResult()
    {
        // Arrange
        var userServiceMock = new Mock<IUserService>();
        userServiceMock.Setup(repo => repo.GetAllUsers()).ReturnsAsync(new List<User>());

        var controller = new UsersController(userServiceMock.Object);

        // Act
        var result = await controller.GetAllUsers();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task CreateAsync_ReturnsCreatedAtAction()
    {
        // Arrange
        var userServiceMock = new Mock<IUserService>();
        userServiceMock
            .Setup(repo => repo
            .CreateAsync(It.IsAny<User>()))
            .ReturnsAsync(true);

        var controller = new UsersController(userServiceMock.Object);

        //var filler = new Filler<List<User>>();
        //var newUser = filler.Create();
        var newUser = new User() { Id = 99, Name = "Jhon Doe" };

        //Act
        var result = await controller.CreateUser(newUser);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public async Task UpdateAsync_ReturnsCreatedAtAction()
    {
        // Arrange
        var userMock = new Mock<IUserService>();
        userMock.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<User>()))
            .ReturnsAsync(true);

        var controller = new UsersController(userMock.Object);

        var filler = new Filler<User>();
        var updatedUser = filler.Create();

        var a = new User() { Id = 3, Name = "Completed" };

        // Act
        var result = await controller.UpdateUser(updatedUser);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task DeleteAsync_ReturnsOk()
    {
        // Arrange
        var userMock = new Mock<IUserService>();
        userMock.Setup(x => x.DeleteAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        var controller = new UsersController(userMock.Object);

        // Act
        var result = await controller.DeleteUser(2);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetUserById_ReturnsOkResult()
    {
        // Arrange
        var userServiceMock = new Mock<IUserService>();
        userServiceMock.Setup(repo => repo
        .GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(new User());

        var controller = new UsersController(userServiceMock.Object);

        // Act
        var result = await controller.GetUserById(2);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }
}
