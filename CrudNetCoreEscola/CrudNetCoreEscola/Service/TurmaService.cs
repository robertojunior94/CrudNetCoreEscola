using CrudNetCoreEscola.Model;
using CrudNetCoreEscola.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Service
{
    public class TurmaService
    {
        public Turma Create(Turma data)
        {
            return new TurmaRepository().Create(data);
        }

        public Turma Update(Turma data)
        {
            return new TurmaRepository().Update(data);
        }

        public void Delete(int id)
        {
            new TurmaRepository().Delete(id);
        }

        public List<Turma> ListPaginada(int pagina, int qtdPagina)
        {
            return new TurmaRepository().ListPaginada(pagina, qtdPagina);
        }

        public Turma GetById(int id)
        {
            return new TurmaRepository().GetById(id);
        }
    }
}
