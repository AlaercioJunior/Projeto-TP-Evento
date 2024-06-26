using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicos;


namespace Evento
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IServEvento _servEvento;

        public EventoController(IServEvento servEvento)
        {
            _servEvento = servEvento;
        }

        [HttpPost]
        public ActionResult Inserir(InserirEventoDTO inserirDto)
        {
            try
            {
                _servEvento.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var eventos = _servEvento.BuscarTodos();

                return Ok(eventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("MaisVendidos")]
        public IActionResult BuscarMaisVendidos()
        {
            try
            {
                var eventos = _servEvento.BuscarMaisVendidos();

                return Ok(eventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult CancelarEvento(int id, bool CancelarEvento)
        {
            try
            {
                _servEvento.Cancelar(id, CancelarEvento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("BuscarEvento")] 
        public IActionResult BuscarEvento(InserirVendaDTO inserirVendaDto)
        {
            try
            {
                Console.WriteLine("ID "+inserirVendaDto.EventoId+ "ingressos"+ inserirVendaDto.Quantidade);
                 _servEvento.BuscarEvento(inserirVendaDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("AtualizaIngressos")]
        public IActionResult AtualizaIngressos(AtualizarIngressos atualizarIngressos)
        {
            try
            {
                _servEvento.AtualizaIngressos(atualizarIngressos);
                Console.WriteLine(atualizarIngressos);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
