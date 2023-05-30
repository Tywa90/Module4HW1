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

public class AuthentificationService : IAuthentificationService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<AuthentificationService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApi = "api/register";

    public AuthentificationService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<AuthentificationService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<AuthResponse> RegisterUser(string email, string password)
    {
        var result = await _httpClientService.SendAsync<AuthResponse, AuthRequest>(
            $"{_options.Host}{_userApi}",
            HttpMethod.Post,
            new AuthRequest()
            {
                Email = email,
                Password = password
            });

        if (result != null)
        {
            _logger.LogWarning($"User was successful registered with id = {result.Token}");
        }

        return result;
    }
}