using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Requests;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services;

public class LoginService : IAuthentificationService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<LoginService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApiReg = "api/register";
    private readonly string _userApiLogIn = "api/login";

    public LoginService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<LoginService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<AuthResponse> RegisterUser(string email, string password)
    {
        var result = await _httpClientService.SendAsync<AuthResponse, AuthRequest>(
            $"{_options.Host}{_userApiReg}",
            HttpMethod.Post,
            new AuthRequest()
            {
                Email = email,
                Password = password
            });

        if (result != null && result.Error == null)
        {
            _logger.LogInformation($"Register successful with id = {result.Id}");
        }
        else
        {
            _logger.LogWarning($"Register unsuccessful: {result.Error}");
        }

        return result;
    }

    public async Task<AuthResponse> LogInUser(string email, string password)
    {
        var result = await _httpClientService.SendAsync<AuthResponse, AuthRequest>(
            $"{_options.Host}{_userApiLogIn}",
            HttpMethod.Post,
            new AuthRequest()
            {
                Email = email,
                Password = password
            });

        if (result != null && result.Error == null)
        {
            _logger.LogInformation($"LoggedIn successful. Token = {result.Token}");
        }
        else
        {
            _logger.LogWarning($"LogIn unsuccessful: {result.Error}");
        }

        return result;
    }
}