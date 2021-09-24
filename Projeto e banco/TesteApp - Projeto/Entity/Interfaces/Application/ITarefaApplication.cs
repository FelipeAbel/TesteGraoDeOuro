using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Entities;
using Entity.Request;
using Entity.Response;

namespace Entity.Interfaces.Application
{
    public interface ITarefaApplication
    {
        Task<List<Tarefa>> ObterTodas();
        Task<List<Tarefa>> ObterTodasConcluidas();
        Task<Tarefa> ObterTarefaPorId(long id);
        Task<TarefaResponse> Inserir(InserirTarefaRequest request);
        Task<TarefaResponse> Editar(EditarTarefaRequest request);
        Task<TarefaResponse> Excluir(ExcluirTarefaRequest request);
    }
}
