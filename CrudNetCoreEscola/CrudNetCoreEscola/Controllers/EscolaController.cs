using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudNetCoreEscola.Model;
using CrudNetCoreEscola.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudNetCoreEscola.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EscolaController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public object Create([FromBody] Escola dados)
        {
            try
            {
                var resultado = new EscolaService().Create(dados);
                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Update")]
        public object Update([FromBody] Escola dados)
        {
            try
            {
                var resultado = new EscolaService().Update(dados);
                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public object Delete(int id)
        {
            try
            {
                new EscolaService().Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("ListPaginada")]
        public object ListPaginada(int pagina, int qtdPagina)
        {
            try
            {
                var resultado = new EscolaService().ListPaginada(pagina, qtdPagina);
                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("ListPaginadaFiltros")]
        public object ListPaginadaFiltros(int pagina, int qtdPagina, int tipoOrdenacao, int usuarioId, int? turmaId, string nomeTurma, string nomeAluno, decimal? nota)
        {
            try
            {
                var resultado = new EscolaService().ListPaginadaFiltros(pagina, qtdPagina, tipoOrdenacao, usuarioId, turmaId, nomeTurma, nomeAluno, nota);
                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("ListMedia")]
        public object ListMedia(int usuarioId, int? turmaId, string nomeTurma, string nomeAluno)
        {
            try
            {
                var resultado = new EscolaService().ListMedia(usuarioId, turmaId, nomeTurma, nomeAluno);
                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public object GetById(int id)
        {
            try
            {
                var resultado = new EscolaService().GetById(id);
                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
