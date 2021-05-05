using ArquiteturaLimpa.Aplicacao.Interfaces;
using ArquiteturaLimpa.Aplicacao.ViewModels;
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao consultar o contato.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContatosViewModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatosService.AdicionarContatos(contato);

                    if (await _contatosService.SalvarMudancas())
                    {
                        return Created($"/api/contatos/{contato.Id}", contato);
                    }
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao incluir o contato.");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ContatosViewModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatosService.AtualizarContatos(contato);

                    if (await _contatosService.SalvarMudancas())
                    {
                        return Created($"/api/contatos/{contato.Id}", contato);
                    }
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao atualizar o contato.");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _contatosService.ExcluirContatos(id);

                if (await _contatosService.SalvarMudancas())
                {
                    return Ok();
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Occoreu um erro ao excluir o contato.");
            }

            return BadRequest();
        }
    }
}
