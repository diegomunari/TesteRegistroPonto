using Microsoft.AspNetCore.Mvc;
using Teste.Domain.Interfaces;
using Teste.Domain.Models;
using Teste.Web.DTOs;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<PontoDTO> GetByColaboradorData(Guid idColaborador)
        {
            var pontos = _pontoRepository.GetByColaborador(idColaborador);

            var resultado = pontos.Select(c => new PontoDTO { Id = c.Id, DataHora = c.DataHora, EntradaSaida = c.EntradaSaida, Colaborador = c.Colaborador });

            return resultado;
        }

        [HttpPost("Busca")]
        public IEnumerable<PontoRegistro> GetByDataColaborador([FromBody] PontoConsulta consulta)
        {
            var pontos = _pontoRepository.GetByData(consulta).OrderBy(x => x.DataHora).ToArray();
            string horasTrabalhadas = "";
            double horasTrabalhadasTotal = 0;

            List<PontoRegistro> result = new List<PontoRegistro>(); 

            for (int i = 0; i < pontos.Count(); i++)
            {
                if (i + 1 < pontos.Count())
                {
                    DateTimeOffset dataAtual = pontos[i].DataHora;

                    //verifica se os registros de ponto a serem calculados são do mesmo dia e se são Entrada e Saída
                    if ((pontos[i].DataHora.Date == pontos[i + 1].DataHora.Date) && (pontos[i].EntradaSaida == 'E' && pontos[i + 1].EntradaSaida == 'S'))
                    {
                        double horas = pontos[i + 1].DataHora.Subtract(pontos[i].DataHora).TotalHours;
                        double part = (int)horas;
                        double fract = (horas - part);
                        double minutos = fract > 0 ? 60 * fract : 0;
                        horasTrabalhadasTotal += horas;

                        horasTrabalhadas = part.ToString("##") + "h " + (minutos > 0 ? "e " + minutos.ToString("00") + "min" : "") ;

                        result.Add(new PontoRegistro
                        {
                            Data = pontos[i].DataHora.Date.ToShortDateString(),
                            colaborador = pontos[i].Colaborador,
                            HoraEntrada = pontos[i].DataHora.ToString("HH:mm"),
                            HoraSaida = pontos[i + 1].DataHora.ToString("HH:mm"),
                            HorasTrabalhadas = horasTrabalhadas,
                            HorasTrabalhadasTotal = ""
                        }); ;
                    }
                }
            }
            double partTotal = (int)horasTrabalhadasTotal;
            double fractTotal = (horasTrabalhadasTotal - partTotal);
            double minutosTotal = fractTotal > 0 ? 60 * fractTotal : 0;

            result[result.Count() -1].HorasTrabalhadasTotal = partTotal.ToString("##") + "h " + (minutosTotal > 0 ? "e " + minutosTotal.ToString("00") + "min" : "");

            return result;
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
