using CrudNetCoreEscola.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Repository
{
    public class EscolaRepository
    {
        private readonly EscolaContext db = new EscolaContext();

        public Escola Create(Escola dados)
        {
            Escola newObject = new Escola()
            {
                Id = dados.Id,
                Nome = dados.Nome,
            };
            db.Escola.Add(newObject);
            db.SaveChanges();
            return newObject;
        }

        public Escola Update(Escola dados)
        {
            var newObject = db.Escola.FirstOrDefault(x => x.Id == dados.Id);
            if (newObject == null) return null;
            newObject.Id = dados.Id;
            newObject.Nome = dados.Nome;
            
            db.SaveChanges();
            return newObject;
        }

        public void Delete(int id)
        {
            var newObject = db.Escola.Include("Turmas").Include("Turmas.Alunos").FirstOrDefault(x => x.Id == id);

            if (newObject?.Id > 0)
            {
                for (var index = 0; newObject.Turmas.Count() > index; index++)
                {
                    for (var count = 0; newObject.Turmas[index].Alunos.Count() > count; count++)
                    {
                        new AlunoRepository().Delete(newObject.Turmas[index].Alunos[count].Id);
                    }

                    new TurmaRepository().Delete(newObject.Turmas[index].Id);
                }
            }

            db.Escola.Remove(newObject);
            db.SaveChanges();
        }

        public List<Escola> ListPaginada(int pagina, int qtdPagina)
        {
            var lista = db.Escola
                .Include("Turmas")
                .Include("Turmas.Alunos")
                .ToList();

            return lista
                .Skip((pagina - 1) * qtdPagina)
                .Take(qtdPagina).ToList();
        }

        public List<Escola> ListPaginadaFiltros(int pagina, int qtdPagina, int tipoOrdenacao, int usuarioId, int? turmaId, string nomeTurma, string nomeAluno, decimal? nota)
        {
            var lista = db.Escola
                .Include("Turmas")
                .Include("Turmas.Alunos")
                .ToList();

            // Realizando filtros
            lista = lista.Where(x => 
                    (turmaId == null || x.Turmas.Any(y => y.Id == turmaId))
                    && (nomeTurma == null || x.Turmas.Any(y => y.Nome.ToLower().Contains(nomeTurma.ToLower())))
                    && (nomeAluno == null || x.Turmas.Any(y => y.Alunos.Any(a=> a.Nome.ToLower().Contains(nomeAluno.ToLower()))))
                    && (nota == null || x.Turmas.Any(y => y.Alunos.Any(a => a.Nota == nota)))
                    ).ToList();

            return lista;
        }

        public List<Escola> ListMedia(int usuarioId, int? turmaId, string nomeTurma, string nomeAluno)
        {
            var lista = db.Escola
                .Include("Turmas")
                .Include("Turmas.Alunos")
                .ToList();

            // Realizando filtros
            lista = lista.Where(x =>
                    (turmaId == null || x.Turmas.Any(y => y.Id == turmaId))
                    && (nomeTurma == null || x.Turmas.Any(y => y.Nome.ToLower().Contains(nomeTurma.ToLower())))
                    && (nomeAluno == null || x.Turmas.Any(y => y.Alunos.Any(a => a.Nome.ToLower().Contains(nomeAluno.ToLower()))))
                    ).ToList();

            return lista;
        }

        public Escola GetById(int id)
        {
            return db.Escola.FirstOrDefault(x => x.Id == id);
        }
    }
}
