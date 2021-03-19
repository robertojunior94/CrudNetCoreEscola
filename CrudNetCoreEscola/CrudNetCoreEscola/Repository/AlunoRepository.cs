using CrudNetCoreEscola.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Repository
{
    public class AlunoRepository
    {
        private readonly EscolaContext db = new EscolaContext();

        public Aluno Create(Aluno dados)
        {
            Aluno newObject = new Aluno()
            {
                Id = dados.Id,
                TurmaId = dados.TurmaId,
                Nome = dados.Nome,
                Nota = dados.Nota,
            };
            db.Aluno.Add(newObject);
            db.SaveChanges();
            return newObject;
        }

        public Aluno Update(Aluno dados)
        {
            var newObject = db.Aluno.FirstOrDefault(x => x.Id == dados.Id);
            if (newObject == null) return null;

            newObject.Id = dados.Id;
            newObject.TurmaId = dados.TurmaId;
            newObject.Nome = dados.Nome;
            newObject.Nota = dados.Nota;

            db.SaveChanges();
            return newObject;
        }

        public void Delete(int id)
        {
            var newObject = db.Aluno.FirstOrDefault(x => x.Id == id);
            db.Aluno.Remove(newObject);
            db.SaveChanges();

        }

        public List<Aluno> ListPaginada(int pagina, int qtdPagina)
        {
            return db.Aluno.Skip((pagina - 1) * qtdPagina)
                .Take(qtdPagina).ToList();
        }

        public Aluno GetById(int id)
        {
            return db.Aluno.FirstOrDefault(x => x.Id == id);
        }
    }
}
