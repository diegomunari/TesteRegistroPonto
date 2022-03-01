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
    public class PontosController : Controller
    {
        private readonly PontoService _pontoService;
        private readonly IRepositoryPonto _pontoRepository;

        public PontosController(PontoService pontoService, IRepositoryPonto pontoRepository)
        {
            _pontoService = pontoService;
            _pontoRepository = pontoRepository;
        }

        [HttpGet("Busca/{idColaborador}")]
        public IEnumerable<PontoDTO> GetByColaborador(Guid idColaborador)
        {
            var pontos = _pontoRepository.GetByColaborador(idColaborador);

            var resultado = pontos.Select(c => new PontoDTO { Id = c.Id, DataHora = c.DataHora, EntradaSaida = c.EntradaSaida, Colaborador = c.Colaborador });

            return resultado;
        }

        [HttpGet]
        public async Task<IEnumerable<PontoDTO>>GetPontos()
        {
            var pontos = await _pontoRepository.GetAll();

            var resultado = pontos.Select(c => new PontoDTO { Id = c.Id, DataHora = c.DataHora, EntradaSaida = c.EntradaSaida, Colaborador = c.Colaborador });

            return resultado;
        }

        [HttpGet("{id}")]
        public async Task<Ponto> GetPonto(Guid id)
        {
            return await _pontoRepository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Ponto item)
        {
            if (item == null)
                return BadRequest(new
                {
                    status = 400,
                    message = "Dados inválidos."
                });

            if (ModelState.IsValid)
            {
                var response = await _pontoRepository.Save(item);
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
