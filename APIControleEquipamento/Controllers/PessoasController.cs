using APIControleEquipamento.Context;
using APIControleEquipamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace APIControleEquipamento.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly ControleDBContext _context;
        public PessoasController(ControleDBContext contexto)
        {
            _context = contexto;
        }
    


 
    [HttpGet]
    public ActionResult<IEnumerable<Pessoa>> Get()
    {
        try
        {
            return _context.Pessoas.AsNoTracking().ToList();
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar obter as pessoa do banco de dados");
        }

    }

    [HttpGet("{id}", Name = "ObterPessoa")]
    public ActionResult<Pessoa> Get(int id)
    {
        try
        {
            var pessoa = _context.Pessoas.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound($"A pessoa com id={id} não foi encontrada");
            }
            return pessoa;
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar obter a pessoa do banco de dados");
        }

    }

    [HttpPost]
    public ActionResult Post([FromBody] Pessoa pessoa)
    {
        try
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterPessoa",
                new { id = pessoa.Id }, pessoa);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar criar uma pessoa");
        }

    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Pessoa pessoa)
    {
        try
        {
            if (id != pessoa.Id)
            {
                return BadRequest($"Não foi possível alterar a pessoa com id={id}");
            }

            _context.Entry(pessoa).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok($"A pessoa com id={id} foi atulizada com sucesso");
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar pessoa com id={id}");
        }

    }

    [HttpDelete("{id}")]
    public ActionResult<Pessoa> Delete(int id)
    {
        try
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa == null)
            {
                return NotFound($"A pessoa com id={id} não foi encontrada");
            }

            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return pessoa;
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar excluir a pessoa com id={id}");
        }

    }
}
}   
