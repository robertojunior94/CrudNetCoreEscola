using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Model
{
    public class Escola
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}
