using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CpfCnpj { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}
