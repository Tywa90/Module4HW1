using System.Threading;
using System.Threading.Tasks;
using ALevelSample.Services.Abstractions;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;
    private readonly IResourceService _resourceService;

    public App(IUserService userService, IResourceService resourceService)
    {
        _userService = userService;
        _resourceService = resourceService;
    }

    public async Task Start()
    {
        var user = await _userService.GetUserById(2);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
        var userList = await _userService.GetUsersList(2);
        var user23 = await _userService.GetUserById(23);

        var resourceSingle = await _resourceService.GetResourceSingle(2);
        var resourceList = await _resourceService.GetResourceList(2);
        var resourceSingle23 = await _resourceService.GetResourceSingle(23);

        var user3 = await _userService.UpdateUserPut("morpheus", "bosss", 2);
        var user5 = await _userService.UpdateUserPatch("morpheus", "zion resident", 2);
        var user6 = await _userService.DeleteUser(2);
    }
}