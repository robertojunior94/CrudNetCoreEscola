using CrudNetCoreEscola.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Repository
{
    public class TurmaRepository
    {
        private readonly EscolaContext db = new EscolaContext();

        public Turma Create(Turma dados)
        {
            Turma newObject = new Turma()
            {
                Id = dados.Id,
                EscolaId = dados.EscolaId,
                Nome = dados.Nome,
            };
            db.Turma.Add(newObject);
            db.SaveChanges();
            return newObject;
        }

        public Turma Update(Turma dados)
        {
            var newObject = db.Turma.FirstOrDefault(x=> x.Id == dados.Id);
            if (newObject == null) return null;

            newObject.Id = dados.Id;
            newObject.EscolaId = dados.EscolaId;
            newObject.Nome = dados.Nome;
        
            db.SaveChanges();
            return newObject;
        }

        public void Delete(int id)
        {
            var newObject = db.Turma.Include("Alunos").FirstOrDefault(x => x.Id == id);

            if (newObject?.Id > 0)
            {
                for (var index = 0; newObject.Alunos.Count() > index; index++)
                {
                    new AlunoRepository().Delete(newObject.Alunos[index].Id);
                }
            }

            db.Turma.Remove(newObject);
            db.SaveChanges();
        }

        public List<Turma> ListPaginada(int pagina, int qtdPagina)
        {
            return db.Turma
                .Include("Alunos")
                .Skip((pagina - 1) * qtdPagina)
                .Take(qtdPagina).ToList();
        }

        public Turma GetById(int id)
        {
            return db.Turma.FirstOrDefault(x => x.Id == id);
        }
    }
}
