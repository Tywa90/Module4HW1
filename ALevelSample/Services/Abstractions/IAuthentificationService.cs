using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

public interface IAuthentificationService
{
    Task<AuthResponse> RegisterUser(string email, string password);
}