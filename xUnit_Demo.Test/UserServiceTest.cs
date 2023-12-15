//using Microsoft.EntityFrameworkCore;
//using Moq;
//using xUnit_Demo.Data;
//using xUnit_Demo.Models;
//using xUnit_Demo.Services.Users;

//namespace xUnit_Demo.Test;

//public class UserServiceTest
//{
//    private readonly Mock<AppDbContext> dbContextMock;

//    public UserServiceTest()
//    {
//        dbContextMock = new Mock<AppDbContext>();
//    }

//    //public void Dispose()
//    //{
//    //    dbContextMock.Dispose();
//    //}

//    [Fact]
//    public async Task CreateAsync_ShouldReturnTrue()
//    {
//        // Arrange
//        var userService = new UserService(dbContextMock.Object);
//        var user = new User { Id = 1, Name = "John Doe" };

//        // Act
//        var result = await userService.CreateAsync(user);

//        // Assert
//        Assert.True(result);
//    }

//    [Fact]
//    public async Task DeleteAsync_ShouldReturnTrue()
//    {
//        // Arrange
//        var userService = new UserService(dbContextMock.Object);
//        var userId = 1;

//        // Act
//        var result = await userService.DeleteAsync(userId);

//        // Assert
//        Assert.True(result);
//    }

//    [Fact]
//    public async Task GetAllUsers_ShouldReturnListOfUsers()
//    {
//        // Arrange
//        var userService = new UserService(dbContextMock.Object);
//        var expectedUsers = new List<User>
//        {
//            new User { Id = 1, Name = "User1" },
//            new User { Id = 2, Name = "User2" },
//        };

//        //dbContextMock.Setup(x => x.Users).ReturnsDbSet(expectedUsers);

//        // Act
//        var result = await userService.GetAllUsers();

//        // Assert
//        Assert.NotNull(result);
//        Assert.IsAssignableFrom<IEnumerable<User>>(result);
//        Assert.Equal(expectedUsers.Count, result.Count());
//        Assert.All(expectedUsers, user => Assert.Contains(result, u => u.Id == user.Id && u.Name == user.Name));

//        // Verify that DbContext.Users.ToList() was called once
//        dbContextMock.Verify(x => x.Users.ToList(), Times.Once);
//    }

//    [Fact]
//    public async Task UpdateAsync_ShouldReturnTrue()
//    {
//        // Arrange
//        var userService = new UserService(dbContextMock.Object);
//        var userId = 1;
//        var user = new User { Id = userId, Name = "UpdatedName" };

//        // Act
//        var result = await userService.UpdateAsync(userId, user);

//        // Assert
//        Assert.True(result);
//    }

//    [Fact]
//    public async Task GetByIdAsync_ShouldReturnUser()
//    {
//        // Arrange
//        var userService = new UserService(dbContextMock.Object);
//        var userId = 2;
//        var expectedUser = new User { Id = userId, Name = "John Doe" };

//        dbContextMock.Setup(x => x.Users.FindAsync(userId)).ReturnsAsync(expectedUser);

//        // Act
//        var result = await userService.GetByIdAsync(userId);

//        // Assert
//        Assert.NotNull(result);
//        Assert.IsType<User>(result);
//        Assert.Equal(expectedUser.Id, result.Id);
//        Assert.Equal(expectedUser.Name, result.Name);

//        // Verify that DbContext.Users.FindAsync(userId) was called once
//        dbContextMock.Verify(x => x.Users.FindAsync(userId), Times.Once);
//    }

//}
