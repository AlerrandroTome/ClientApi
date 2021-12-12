using ClientApi.Core.Dtos.Cities;
using ClientApi.Core.Entities;

namespace ClientApi.Core.Interfaces
{
    public interface IManageCityService : IBaseService<City, CreateCityDto, UpdateCityDto>
    {
    }
}
