using CrudNetCoreEscola.Model;
using CrudNetCoreEscola.Model.ReturnView;
using CrudNetCoreEscola.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Service
{
    public class EscolaService
    {
        public Escola Create(Escola data)
        {
            return new EscolaRepository().Create(data);
        }

        public Escola Update(Escola data)
        {
            return new EscolaRepository().Update(data);
        }

        public void Delete(int id)
        {
            new EscolaRepository().Delete(id);
        }

        public List<Escola> ListPaginada(int pagina, int qtdPagina)
        {
            return new EscolaRepository().ListPaginada(pagina, qtdPagina);
        }

        public List<EscolaFiltrosReturnView> ListPaginadaFiltros(int pagina, int qtdPagina, int tipoOrdenacao, int usuarioId, int? turmaId, string nomeTurma, string nomeAluno, decimal? nota)
        {
            List<Escola> lst = new List<Escola>();
            List<EscolaFiltrosReturnView> retorno = new List<EscolaFiltrosReturnView>();

            try
            {
                lst = new EscolaRepository().ListPaginadaFiltros(pagina, qtdPagina, tipoOrdenacao, usuarioId, turmaId, nomeTurma, nomeAluno, nota);

                for (var index = 0; lst.Count() > index; index++)
                {
                    for (var count = 0; lst[index].Turmas.Count > count; count++)
                    {
                        for (var alx = 0; lst[index].Turmas[count].Alunos.Count() > alx; alx++)
                        {
                            var existe = false;
                            for (var idx = 0; retorno.Count() > idx; idx++)
                            {
                                if (retorno[idx].AlunoId == lst[index].Turmas[count].Alunos[alx].Id)
                                {
                                    existe = true;
                                }
                            }

                            if (existe == false)
                            {
                                retorno.Add(new EscolaFiltrosReturnView()
                                {
                                    TurmaId = lst[index].Turmas[count].Id,
                                    AlunoId = lst[index].Turmas[count].Alunos[alx].Id,
                                    NomeTurma = lst[index].Turmas[count].Nome,
                                    NomeAluno = lst[index].Turmas[count].Alunos[alx].Nome,
                                    NotaAluno = lst[index].Turmas[count].Alunos[alx].Nota,
                                });
                            }
                        }
                    }
                }

                // Efetua ordenção de acordo com o tipo enviado
                switch (tipoOrdenacao)
                {
                    case 1: // Order By Nome Turmas
                        retorno = retorno.OrderBy(x => x.NomeTurma).ToList();
                        break;
                    case 2: // Order By Nome Alunos
                        retorno = retorno.OrderBy(x => x.NomeAluno).ToList();
                        break;
                    case 3: // Order By Nota Alunos
                        retorno = retorno.OrderBy(x => x.NotaAluno).ToList();
                        break;
                }

                return retorno
                    .Skip((pagina - 1) * qtdPagina)
                    .Take(qtdPagina).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public List<EscolaMediaReturnView> ListMedia(int usuarioId, int? turmaId, string nomeTurma, string nomeAluno)
        {
            List<Escola> lst = new List<Escola>();
            List<EscolaMediaReturnView> retorno = new List<EscolaMediaReturnView>();

            try
            {
                lst = new EscolaRepository().ListMedia(usuarioId, turmaId, nomeTurma, nomeAluno);


                for (var index = 0; lst.Count > index; index++)
                {
                    if (retorno.Count == 0)
                    {
                        retorno.Add(new EscolaMediaReturnView()
                        {
                            TurmaId = lst[index].Turmas[0].Id,
                            TurmaNome = lst[index].Turmas[0].Nome,
                            Media = (lst[index].Turmas[0].Alunos.Count() > 0 ? (lst[index].Turmas[0].Alunos.Sum(x => x.Nota) / lst[index].Turmas[0].Alunos.Count()) : 0),
                        });
                    }
                    else
                    {
                        for (var count = 0; lst[index].Turmas.Count > count; count++)
                        {
                            var existe = false;
                            for (var idx = 0; retorno.Count() > idx; idx++)
                            {
                                if (retorno[idx].TurmaId == lst[index].Turmas[count].Id)
                                {
                                    existe = true;
                                }
                            }

                            if (existe == false)
                            {
                                retorno.Add(new EscolaMediaReturnView()
                                {
                                    TurmaId = lst[index].Turmas[count].Id,
                                    TurmaNome = lst[index].Turmas[count].Nome,
                                    Media = (lst[index].Turmas[count].Alunos.Count() > 0 ? (lst[index].Turmas[count].Alunos.Sum(x => x.Nota) / lst[index].Turmas[count].Alunos.Count()) : 0),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public Escola GetById(int id)
        {
            return new EscolaRepository().GetById(id);
        }

        public string GetUsuarioLogado(HttpContext _httpContext)
        {
            var currentUser = _httpContext.User;

            if (currentUser.HasClaim(c => c.Type == "Id"))
            {
            }

            return null;
        }
    }
}
