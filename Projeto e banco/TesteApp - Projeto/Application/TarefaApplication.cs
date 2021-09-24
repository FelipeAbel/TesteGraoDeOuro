using System;
using Entity.Interfaces.Application;
using Entity.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Entities;
using Entity.Request;
using Entity.Response;

namespace Application
{
    public class TarefaApplication : ITarefaApplication
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaApplication(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<List<Tarefa>> ObterTodas()
        {
            try
            {
                return await _tarefaRepository.ObterTodas();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Tarefa>> ObterTodasConcluidas()
        {
            try
            {
                return await _tarefaRepository.ObterTodasConcluidas();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Tarefa> ObterTarefaPorId(long id)
        {
            try
            {
                return await _tarefaRepository.ObterTarefaPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TarefaResponse> Inserir(InserirTarefaRequest request)
        {
            try
            {
                var novaTarefa = new Tarefa {Nome = request.Nome};
                await _tarefaRepository.Inserir(novaTarefa);
                var tarefaResponse = new TarefaResponse
                {
                    Mensagem = $"Tarefa {request.Nome} inserida com sucesso!"
                };
                return tarefaResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TarefaResponse> Editar(EditarTarefaRequest request)
        {
            try
            {
                var tarefaResponse = new TarefaResponse();
                var tarefa = await _tarefaRepository.ObterTarefaPorId(request.Id);

                if (tarefa != null)
                {
                    tarefa.Nome = request.Nome != "string" ? request.Nome : tarefa.Nome;
                    tarefa.IsConcluida = request.IsConcluida;
                    await _tarefaRepository.Editar(tarefa);
                    tarefaResponse.Mensagem = $"Tarefa {request.Id} editada com sucesso!";
                }

                tarefaResponse.Mensagem = $"Tarefa {request.Id} não encontrada!";
                return tarefaResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TarefaResponse> Excluir(ExcluirTarefaRequest request)
        {
            try
            {
                var tarefaResponse = new TarefaResponse();
                var tarefa = await _tarefaRepository.ObterTarefaPorId(request.Id);

                if (tarefa != null)
                {
                    await _tarefaRepository.Exluir(tarefa);
                    tarefaResponse.Mensagem = $"Tarefa {request.Id} excluida com sucesso!";
                }

                tarefaResponse.Mensagem = $"Tarefa {request.Id} não encontrada!";
                return tarefaResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
