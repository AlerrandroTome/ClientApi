using ClientApi.Core.Dtos;
using ClientApi.Core.Dtos.Cities;
using ClientApi.Core.Entities;
using ClientApi.Core.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Creates a new city.
        /// </summary>
        [ProducesResponseType(typeof(Response<City>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCityDto dto)
        {
            var response = await _service.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Removes a city.
        /// </summary>
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

        /// <summary>
        /// Only used in odata request.
        /// </summary>
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        [ODataRoute]
        public IActionResult Get() => Ok(_service.Get());

        /// <summary>
        /// Updates a city.
        /// </summary>
        [ProducesResponseType(typeof(Response<City>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCityDto dto)
        {
            return Ok(await _service.UpdateAsync(dto));
        }
    }
}
