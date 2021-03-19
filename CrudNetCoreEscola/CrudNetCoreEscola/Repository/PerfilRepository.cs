using CrudNetCoreEscola.Model;
using System.Collections.Generic;
using System.Linq;

namespace CrudNetCoreEscola.Repository
{
    public class PerfilRepository
    {
        private readonly EscolaContext db = new EscolaContext();

        public Perfil Create(Perfil dados)
        {
            Perfil newObject = new Perfil()
            {
                Id = dados.Id,
                Descricao = dados.Descricao,
            };
            db.Perfil.Add(newObject);
            db.SaveChanges();
            return newObject;
        }

        public Perfil Update(Perfil dados)
        {
            Perfil newObject = new Perfil()
            {
                Id = dados.Id,
                Descricao = dados.Descricao,
            };

            db.SaveChanges();
            return newObject;
        }

        public List<Perfil> ListPaginada(int pagina, int qtdPagina)
        {
            return db.Perfil
                .Skip((pagina - 1) * qtdPagina)
                .Take(qtdPagina).ToList();
        }

        public Perfil GetById(int id)
        {
            return db.Perfil.FirstOrDefault(x => x.Id == id);
        }
    }
}
