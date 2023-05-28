using System.Threading.Tasks;
using ALevelSample.Services.Abstractions;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;

    public App(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Start()
    {
        var user = await _userService.GetUserById(2);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
        var userList = await _userService.GetUsersList(2);
        var user23 = await _userService.GetUserById(23);
    }
}