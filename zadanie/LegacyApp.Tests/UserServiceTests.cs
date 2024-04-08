namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        // arange - wez zmienne, klasy, funkcje cokolwiek co potrzebujesz do wykonania funkcji testowej
        var userService = new UserService();

        // act - wykonaj funkcje
        var result = userService.AddUser(
            null,
            "nowak",
            "nowakk@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // assert - czy to co zwraca jest tym co chcesz
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

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        //arange
        var userService = new UserService();
        
        //act
        var result = userService.AddUser(
            "Karol",
            "nowak",
            "nowakkgmailcom",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        //assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        //arange
        var userService = new UserService();
        
        //act
        var result = userService.AddUser(
            "Karol",
            "nowak",
            "nowakk@gmail.com",
            DateTime.Parse("2004-01-01"),
            1
        );
        
        //assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        //arange
        var userService = new UserService();
        var cr = new ClientRepository();

        
        //act
        var result = userService.AddUser(
            "Karol",
            "Malewski",
            "nowakk@gmail.com",
            DateTime.Parse("2001-01-01"),
            2
        );
        
        //assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        //arange
        var userService = new UserService();

        
        //act
        var result = userService.AddUser(
            "Karol",
            "Smith",
            "nowakk@gmail.com",
            DateTime.Parse("2001-01-01"),
            3
        );
        
        //assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        //arange
        var userService = new UserService();

        
        //act
        var result = userService.AddUser(
            "Karol",
            "Kwiatkowski",
            "nowakk@gmail.com",
            DateTime.Parse("2001-01-01"),
            5
        );
        
        //assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        //arange
        var userService = new UserService();

        
        //act
        var result = userService.AddUser(
            "Karol",
            "Andrzejewicz",
            "nowakk@gmail.com",
            DateTime.Parse("2001-01-01"),
            6
        );
        
        //assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        //arange
        var userService = new UserService();

        
        //act
        Action action = () => {var result = userService.AddUser(
            "Karol",
            "Andrzejewicz",
            "nowakk@gmail.com",
            DateTime.Parse("2001-01-01"),
            6
        ); };

        
        //assert
        Assert.Throws<ArgumentException>(action);
    }
}