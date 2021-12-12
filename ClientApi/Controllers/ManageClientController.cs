using ClientApi.Core.Dtos.Clients;
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
    [ODataRoutePrefix("Client")]
    public class ManageClientController : ControllerBase
    {
        private readonly IManageClientService _service;

        public ManageClientController(IManageClientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 0)]
        [ODataRoute]
        public IActionResult Get() => Ok(_service.Get());

        [HttpPut]
        public async Task<IActionResult> Update(UpdateClientDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }
    }
}
