namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        // arange
        var userService = new UserService();

        // act
        var result = userService.AddUser(
            null,
            "nowak",
            "nowakk@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        // arange
        var userService = new UserService();

        // act

        Action action = () => {var result = userService.AddUser(
            "Jan",
            "nowak",
            "nowakk@gmail.com",
            DateTime.Parse("2000-01-01"),
            100
        ); };

        // assert
        Assert.Throws<ArgumentException>(action);
    }
}