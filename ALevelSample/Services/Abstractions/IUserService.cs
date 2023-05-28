using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);

    Task<UserDto[]> GetUsersList(int page);

    Task<UserResponse> CreateUser(string name, string job);

    Task<UserUpdateResponse> UpdateUserPut(string name, string job, int id);
}