using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.DTO.ContaDTO;
using MyFirstAPI.DTO.TransacaoDTO;
using MyFirstAPI.Models;
using MyFirstAPI.Models.Enum;
using MyFirstAPI.Repository;
using MyFirstAPI.Service;
using MyFirstAPI.UseCase.Contas.GetAllContas;
using System;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/contas")]
    public class ContasController(IContaService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<ContaViewDTO>>> GetContas([FromServices] GetAllContasHandler getAll)
        {
            try
            {
                var contasResponse = await getAll.Execute();
                return Ok(contasResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContaViewDTO>> GetContaById([FromRoute] Guid id)
        {
            var conta = await service.GetContaByIdAsync(id);
            if (conta == null)
            {
                return NotFound(new { message = "Conta não encontrada" });
            }

            return Ok(conta);
        }

        [HttpPost]
        public async Task<ActionResult<ContaViewDTO>> CreateConta([FromBody] ContaInputDTO input)
        {
            try
            {
                ContaViewDTO novaConta = await service.CreateContaAsync(input);

                return CreatedAtAction(
                nameof(GetContaById),
                new { numero = novaConta.Numero },
                novaConta
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("deposito/{id}")]
        public async Task<ActionResult<ContaViewDTO>> Deposito([FromBody] TransacaoInputDTO input, [FromRoute] Guid id)
        {
            decimal value = input.Valor;
            try
            {
                ContaViewDTO response = await service.DepositarAsync(id, value);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("saque/{id}")]
        public async Task<ActionResult<ContaViewDTO>> Saque([FromBody] TransacaoInputDTO input, [FromRoute] Guid id)
        {
            decimal value = input.Valor;
            try
            {
                ContaViewDTO response = await service.SacarAsync(id, value);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConta([FromRoute] Guid id)
        {
            try
            {
                bool result = await service.DeleteContaAsync(id);
                if (!result)
                {
                    return NotFound(new { message = "Conta não encontrada" });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }
    }
}