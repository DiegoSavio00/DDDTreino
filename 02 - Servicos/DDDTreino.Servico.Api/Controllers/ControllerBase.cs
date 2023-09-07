using DDDTreino.Aplicao.DTO;
using DDDTreino.Aplicao.Interfaces;
using DDDTreino.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace DDDTreino.Servico.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ControllerBase<Entidade, EntidadeDTO> : Controller
        where Entidade : EntidadeBase
        where EntidadeDTO : BaseDTO
    {
        readonly protected IAppBase<Entidade, EntidadeDTO> _app;

        public ControllerBase(IAppBase<Entidade, EntidadeDTO> app)
        {
            _app = app;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Listar()
        {
            try
            {
                var livros = _app.SelecionarTodos();
                return new OkObjectResult(livros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult SelecionarPorId(int id)
        {
            try
            {
                var livros = _app.SelecionarPorId(id);
                return new OkObjectResult(livros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] EntidadeDTO entidadeDto)
        {
            try
            {
                return new OkObjectResult(_app.Incluir(entidadeDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] EntidadeDTO entidadeDto)
        {
            try
            {
                _app.Alterar(entidadeDto);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _app.Excluir(id);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
