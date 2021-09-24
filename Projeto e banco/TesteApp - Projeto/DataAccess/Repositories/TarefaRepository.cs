using System;
using Entity.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using Entity.Entities;

namespace DataAccess.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public async Task<List<Tarefa>> ObterTodas()
        {
            try
            {
                using (var _context = new APIDbContext())
                {
                    return _context.Tarefas.ToList();
                }
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
                using (var _context = new APIDbContext())
                {
                    return _context.Tarefas.Where(x => x.IsConcluida).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Tarefa> ObterTarefaPorId(long Id)
        {
            try
            {
                using (var _context = new APIDbContext())
                {
                    return _context.Tarefas.FirstOrDefault(x => x.Id == Id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task Inserir(Tarefa tarefa)
        {
            try
            {
                using (var _context = new APIDbContext())
                {
                    _context.Add(tarefa);
                    _context.SaveChanges();
                    return Task.CompletedTask;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task Editar(Tarefa tarefa)
        {
            try
            {
                using (var _context = new APIDbContext())
                {
                    _context.Update(tarefa);
                    _context.SaveChanges();
                    return Task.CompletedTask;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task Exluir(Tarefa tarefa)
        {
            try
            {
                using (var _context = new APIDbContext())
                {
                    _context.Remove(tarefa);
                    _context.SaveChanges();
                    return Task.CompletedTask;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
