using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

public interface IResourceService
{
    Task<ResourceDto> GetResourceSingle(int id);
    Task<ResourceDto[]> GetResourceList(int page);
}