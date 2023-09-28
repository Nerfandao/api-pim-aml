using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TESTE_API.Entities;
using TESTE_API.Infraestrutura;
using TESTE_API.Model;
using TESTE_API.ViewModel;

namespace TESTE_API.Controllers
{
    [ApiController]
    [Route("controle-de-horas")]
    public class ControleDeHoraController : ControllerBase
    {
        private FuncionarioRepository funcionarioRepository;

        public ControleDeHoraController(FuncionarioRepository _funcionarioRepository)
        {
            funcionarioRepository = _funcionarioRepository;
        }
        [HttpPost]
        public ActionResult PostControleDeHoras([FromBody] ControleDeHorasInputModel input)
        {
            // Cálculo das horas totais
            TimeSpan horasTotais = input.DataSaida - input.DataEntrada;
            decimal horasTotaisDecimal = (decimal)horasTotais.TotalHours;

            // Inserção dos dados no banco de dados
            var controleDeHoras = new ControleDeHora
            {
                IdFuncionario = input.IdFuncionario,
                Mes = input.Mes,
                DataEntrada = input.DataEntrada,
                DataSaida = input.DataSaida,
                HorasTotal = horasTotaisDecimal
            };

            PostgressContext context = new PostgressContext();
            context.ControleDeHoras.Add(controleDeHoras);
            context.SaveChanges();

            return Ok();
        }
    }
}

