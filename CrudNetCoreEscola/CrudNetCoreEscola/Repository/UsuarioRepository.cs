using CrudNetCoreEscola.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Repository
{
    public class UsuarioRepository
    {
        private readonly EscolaContext db = new EscolaContext();

        public Usuario Create(Usuario dados)
        {
            Usuario newObject = new Usuario()
            {
                Id = dados.Id,
                Nome = dados.Nome,
                Email = dados.Senha
            };
            db.Usuario.Add(newObject);
            db.SaveChanges();
            return newObject;
        }

        public Usuario Update(Usuario dados)
        {
            Usuario newObject = new Usuario()
            {
                Id = dados.Id,
                Nome = dados.Nome,
                Email = dados.Email,
                //Senha = dados.Senha
            };

            db.SaveChanges();
            return newObject;
        }

        public List<Usuario> ListPaginada(int pagina, int qtdPagina)
        {
            return db.Usuario
                .Skip((pagina - 1) * qtdPagina)
                .Take(qtdPagina).ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return db.Usuario.Include("Perfil").FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public Usuario GetById(int id)
        {
            return db.Usuario.FirstOrDefault(x => x.Id == id);
        }
    }
}
