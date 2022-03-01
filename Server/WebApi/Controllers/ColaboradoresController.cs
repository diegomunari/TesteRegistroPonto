using Microsoft.AspNetCore.Mvc;
using Teste.Domain.Interfaces;
using Teste.Domain.Models;
using Teste.Web.DTOs;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ColaboradoresController : Controller
    {
        private readonly ColaboradorService _colaboradorService;
        private readonly IRepository<Colaborador> _colaboradorRepository;

        public ColaboradoresController(ColaboradorService colaboradorService, IRepository<Colaborador> colaboradorRepository)
        {
            _colaboradorService = colaboradorService;
            _colaboradorRepository = colaboradorRepository; 
        }

        [HttpGet]
        public async Task<IEnumerable<ColaboradorDTO>> GetColaboradores()
        {
            var colaboradores = await _colaboradorRepository.GetAll();

            var resultado = colaboradores.Select(c => new ColaboradorDTO { Id = c.Id, Nome = c.Nome, Supervisor = c.Supervisor });

            return resultado;
        }

        [HttpGet("{id}")]
        public async Task<Colaborador> GetColaborador(Guid id)
        {
            return await _colaboradorRepository.GetById(id);
            
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Colaborador item)
        {
            if (item == null)
                return BadRequest(new
                {
                    status = 400,
                    message = "Dados inválidos."
                });

            if (ModelState.IsValid)
            {
                var response = await _colaboradorRepository.Save(item);
                if (response.Equals("success"))
                    return Ok(new
                    {
                        status = HttpContext.Response.StatusCode,
                        message = "Sucesso",
                        data = item,
                    });

                return BadRequest(new
                {
                    status = 400,
                    message = response
                });
            }
            else return BadRequest(new
            {
                status = 400,
                message = ModelState.Values.SelectMany(m => m.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList()
            });
        }
    }
}
