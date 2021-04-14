using ArquiteturaLimpa.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArquiteturaLimpa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly IContatosServico _contatosService;

        public ContatosController(IContatosServico contatosService)
        {
            _contatosService = contatosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _contatosService.ListarContatos();

                return Ok(resultado);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao consultar os contatos");
            }
        }

        [HttpGet("{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var resultado = await _contatosService.ListarContato(nome);

                return Ok(resultado);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao consultar o contato");
            }
        }
    }
}
