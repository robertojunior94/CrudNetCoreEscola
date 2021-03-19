using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudNetCoreEscola.Model;
using CrudNetCoreEscola.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudNetCoreEscola.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public object Create([FromBody] Aluno dados)
        {
            try
            {
                var resultado = new AlunoService().Create(dados);
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
        public object Update([FromBody] Aluno dados)
        {
            try
            {
                var resultado = new AlunoService().Update(dados);
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
                new AlunoService().Delete(id);
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
                var resultado = new AlunoService().ListPaginada(pagina, qtdPagina);
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
                var resultado = new AlunoService().GetById(id);
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
