using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Data;
using MyFirstAPI.DTO.ClienteDTO;
using MyFirstAPI.Models;
using MyFirstAPI.Repository;
using MyFirstAPI.Service;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController(IClienteService service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ClienteViewDTO>> CreateCliente([FromBody] ClienteInputDTO input)
        {
            try
            {
                ClienteViewDTO response = await service.CreateClienteAsync(input);
                return CreatedAtAction(
                    nameof(GetClienteById),
                    new { nome = response.Name },
                    response
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewDTO>> GetClienteById([FromRoute] Guid id)
        {
            try
            {
                ClienteViewDTO? cliente = await service.GetByClienteIdAsync(id);
                if (cliente == null)
                {
                    return NotFound(new { message = "Cliente não encontrado" });
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }


        }
    }
}
