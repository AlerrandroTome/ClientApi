using ClientApi.Core.Dtos.Cities;
using ClientApi.Core.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings]
    [Route("api/[controller]")]
    [ODataRoutePrefix("City")]
    public class ManageCityController : ControllerBase
    {
        private readonly IManageCityService _service;

        public ManageCityController(IManageCityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCityDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        [ODataRoute]
        public IActionResult Get() => Ok(_service.Get());

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCityDto dto)
        {
            return Ok(await _service.UpdateAsync(dto));
        }
    }
}
