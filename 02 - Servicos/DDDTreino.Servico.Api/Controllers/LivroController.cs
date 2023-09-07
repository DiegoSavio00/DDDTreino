using DDDTreino.Aplicao.DTO;
using DDDTreino.Aplicao.Interfaces;
using DDDTreino.Dominio.Entidades;

namespace DDDTreino.Servico.Api.Controllers
{
    public class LivroController : ControllerBase<Livro, LivroDTO>
    {
        public LivroController(ILivroApp app) : base(app) { }
    }
}
