using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Entities;

namespace Entity.Interfaces.Repository
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> ObterTodas();
        Task<List<Tarefa>> ObterTodasConcluidas();
        Task<Tarefa> ObterTarefaPorId(long Id);
        Task Inserir(Tarefa tarefa);
        Task Editar(Tarefa tarefa);
        Task Exluir(Tarefa tarefa);
    }
}
