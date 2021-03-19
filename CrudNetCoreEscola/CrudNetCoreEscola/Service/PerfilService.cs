using CrudNetCoreEscola.Model;
using CrudNetCoreEscola.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCorePerfil.Service
{
    public class PerfilService
    {
        public Perfil Create(Perfil data)
        {
            return new PerfilRepository().Create(data);
        }

        public Perfil Update(Perfil data)
        {
            return new PerfilRepository().Update(data);
        }

        public List<Perfil> ListPaginada(int pagina, int qtdPagina)
        {
            return new PerfilRepository().ListPaginada(pagina, qtdPagina);
        }

        public Perfil GetById(int id)
        {
            return new PerfilRepository().GetById(id);
        }
    }
}
