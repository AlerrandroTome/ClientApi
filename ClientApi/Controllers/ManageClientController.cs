using ClientApi.Core.Dtos;
using ClientApi.Core.Dtos.Clients;
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
    [ODataRoutePrefix("Client")]
    public class ManageClientController : ODataController
    {
        private readonly IManageClientService _service;

        public ManageClientController(IManageClientService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new client.
        /// </summary>
        [ProducesResponseType(typeof(Response<Client>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateClientDto dto)
        {
            var response = await _service.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Removes a client.
        /// </summary>
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        [ODataRoute]
        public IActionResult Get() => Ok(_service.Get());

        /// <summary>
        /// Updates a client.
        /// </summary>
        [ProducesResponseType(typeof(Response<Client>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateClientDto dto)
        {
            var response = await _service.UpdateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
