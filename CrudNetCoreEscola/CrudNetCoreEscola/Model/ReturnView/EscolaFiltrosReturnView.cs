using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Model.ReturnView
{
    public class EscolaFiltrosReturnView
    {
        public int TurmaId{ get; set; }
        public int AlunoId { get; set; }
        public string NomeTurma { get; set; }
        public string NomeAluno { get; set; }
        public decimal NotaAluno { get; set; }
    }
}
