using Entity.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Entities;
using Entity.Request;
using Entity.Response;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaApplication _tarefaApplication;
        
        public TarefaController(ITarefaApplication tarefaApplication)
        {
            _tarefaApplication = tarefaApplication;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tarefa>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("tarefa/obterTodas")]
        public async Task<ActionResult> ObterTodas()
        {
            try
            {
                var tarefas = await _tarefaApplication.ObterTodas();

                if (tarefas is null || !tarefas.Any())
                    return NoContent();

                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tarefa>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("tarefa/obterTodasConcluidas")]
        public async Task<ActionResult> ObterTodasConcluidas()
        {
            try
            {
                var tarefas = await _tarefaApplication.ObterTodasConcluidas();

                if (tarefas is null || !tarefas.Any())
                    return NoContent();

                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("tarefa/inserir")]
        public async Task<ActionResult> Inserir(InserirTarefaRequest request)
        {
            try
            {
                var response = await _tarefaApplication.Inserir(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("tarefa/editar")]
        public async Task<ActionResult> Editar(EditarTarefaRequest request)
        {
            try
            {
                var response = await _tarefaApplication.Editar(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("tarefa/excluir")]
        public async Task<ActionResult> Excluir(ExcluirTarefaRequest request)
        {
            try
            {
                var response = await _tarefaApplication.Excluir(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
