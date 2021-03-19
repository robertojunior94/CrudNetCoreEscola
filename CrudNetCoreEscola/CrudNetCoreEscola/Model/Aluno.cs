using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Model
{
    public class Aluno
    {
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public string Nome { get; set; }
        public decimal Nota { get; set; }
        
    }
}
