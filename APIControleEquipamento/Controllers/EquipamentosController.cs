using APIControleEquipamento.Context;
using APIControleEquipamento.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIControleEquipamento.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly ControleDBContext _context;
        public EquipamentosController(ControleDBContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Equipamento>> Get()
        {
            try
            {
                return _context.Equipamentos.AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter as equipamento do banco de dados");
            }

        }

        [HttpGet("{id}", Name = "ObterEquipamento")]
        public ActionResult<Equipamento> Get(int id)
        {
            try
            {
                var equipamento = _context.Equipamentos.AsNoTracking().FirstOrDefault(p => p.Id == id);
                if (equipamento == null)
                {
                    return NotFound($"O equipamento com id={id} não foi encontrado");
                }
                return equipamento;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar obter equipamento do banco de dados");
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] Equipamento equipamento)
        {
            try
            {
                _context.Equipamentos.Add(equipamento);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterEquipamento",
                    new { id = equipamento.Id }, equipamento);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao tentar criar um equipamento");
            }

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Equipamento equipamento)
        {
            try
            {
                if (id != equipamento.Id)
                {
                    return BadRequest($"Não foi possível alterar equipamento com id={id}");
                }

                _context.Entry(equipamento).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok($"O peequipamento com id={id} foi atulizado com sucesso");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar equipamento com id={id}");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<Equipamento> Delete(int id)
        {
            try
            {
                var equipamento = _context.Equipamentos.FirstOrDefault(p => p.Id == id);

                if (equipamento == null)
                {
                    return NotFound($"O equipamento com id={id} não foi encontrada");
                }

                _context.Equipamentos.Remove(equipamento);
                _context.SaveChanges();
                return equipamento;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     $"Erro ao tentar excluir equipamento com id={id}");
            }

        }
    }
}

