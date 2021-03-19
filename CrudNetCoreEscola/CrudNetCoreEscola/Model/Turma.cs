using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Model
{
    public class Turma
    {
        public int Id { get; set; }
        public int EscolaId { get; set; }
        public string Nome { get; set; }

        public virtual List<Aluno> Alunos { get; set; }
    }
}
