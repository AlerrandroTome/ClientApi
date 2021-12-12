using ClientApi.Core.Dtos.Base;

namespace ClientApi.Core.Dtos.Cities
{
    public class UpdateCityDto : BaseUpdateDto
    {
        public string Name { get; set; }
        public string State { get; set; }
    }
}
