using APIControleEquipamento.Context;
using APIControleEquipamento.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIControleEquipamento.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CautelasController : ControllerBase
    {
        private readonly ControleDBContext _context;
        public CautelasController(ControleDBContext contexto)
        {
            _context = contexto;
        }




        [HttpGet]
        public ActionResult<IEnumerable<Cautela>> Get()
        {
            try
            {
                return _context.Cautelas.AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter a cautela do banco de dados");
            }

        }

        [HttpGet("{id}", Name = "ObterCautela")]
        public ActionResult<Cautela> Get(int id)
        {
            try
            {
                var cautela = _context.Cautelas.AsNoTracking().FirstOrDefault(p => p.Id == id);
                if (cautela == null)
                {
                    return NotFound($"A cautela com id={id} não foi encontrada");
                }
                return cautela;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter a cautela do banco de dados");
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] Cautela cautela)
        {
            try
            {
                _context.Cautelas.Add(cautela);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterCautela",
                    new { id = cautela.Id }, cautela);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar criar uma cautela");
            }

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cautela cautela)
        {
            try
            {
                if (id != cautela.Id)
                {
                    return BadRequest($"Não foi possível alterar a cautela com id={id}");
                }

                _context.Entry(cautela).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok($"A cautela com id={id} foi atulizada com sucesso");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar cautela com id={id}");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<Cautela> Delete(int id)
        {
            try
            {
                var cautela = _context.Cautelas.FirstOrDefault(p => p.Id == id);

                if (cautela == null)
                {
                    return NotFound($"A cautela com id={id} não foi encontrada");
                }

                _context.Cautelas.Remove(cautela);
                _context.SaveChanges();
                return cautela;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     $"Erro ao tentar excluir a cautela com id={id}");
            }

        }
    }
}

