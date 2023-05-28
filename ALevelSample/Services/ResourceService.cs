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

public class ResourceService : IResourceService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<ResourceService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApi = "api/unknown/";
    private readonly string _userApiList = "api/unknown?page=";

    public ResourceService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<ResourceService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<ResourceDto> GetResourceSingle(int id)
    {
        var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>($"{_options.Host}{_userApi}{id}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"Resource with id = {result.Data.Id} was found with name: {result.Data.Name}");
        }
        else
        {
            _logger.LogWarning($"Resource with id = {id} was not found");
        }

        return result?.Data;
    }

    public async Task<ResourceDto[]> GetResourceList(int page)
    {
        var result = await _httpClientService.SendAsync<ResourceListResponce<ResourceDto>, object>($"{_options.Host}{_userApiList}{page}", HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"Total resources = {result.Total}. Resources on page {page} = {result.Data.Length}");
        }

        return result?.Data;
    }
}