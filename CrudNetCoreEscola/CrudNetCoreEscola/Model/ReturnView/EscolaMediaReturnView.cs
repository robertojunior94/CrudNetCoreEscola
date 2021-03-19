using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Model.ReturnView
{
    public class EscolaMediaReturnView
    {
        public int TurmaId { get; set; }
        public string TurmaNome { get; set; }
        public decimal Media { get; set; }
    }
}
