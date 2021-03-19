using CrudNetCoreEscola.Model;
using CrudNetCoreEscola.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Service
{
    public class AlunoService
    {
        public Aluno Create(Aluno data)
        {
            return new AlunoRepository().Create(data);
        }

        public Aluno Update(Aluno data)
        {
            return new AlunoRepository().Update(data);
        }

        public void Delete(int id)
        {
            new AlunoRepository().Delete(id);
        }

        public List<Aluno> ListPaginada(int pagina, int qtdPagina)
        {
            return new AlunoRepository().ListPaginada(pagina, qtdPagina);
        }

        public Aluno GetById(int id)
        {
            return new AlunoRepository().GetById(id);
        }
    }
}
