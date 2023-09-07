using AutoMapper;
using DDDTreino.Aplicao.DTO;
using DDDTreino.Aplicao.Interfaces;
using DDDTreino.Dominio.Entidades;
using DDDTreino.Dominio.Interfaces.Servicos;

namespace DDDTreino.Aplicao.Servicos
{
    public class ServicoAppBase<TEntidade, TEntidadeDTO> : IAppBase<TEntidade, TEntidadeDTO>
        where TEntidade : EntidadeBase
        where TEntidadeDTO : BaseDTO
    {
        protected readonly IServicoBase<TEntidade> _service;
        protected readonly IMapper _mapper;

        public ServicoAppBase(IServicoBase<TEntidade> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public void Alterar(TEntidadeDTO entidadeDTO)
        {
            _service.Alterar(_mapper.Map<TEntidade>(entidadeDTO));
        }

        public void Excluir(TEntidadeDTO entidadeDTO)
        {
            _service.Excluir(_mapper.Map<TEntidade>(entidadeDTO));
        }

        public void Excluir(int id)
        {
            _service.Excluir(id);
        }

        public int Incluir(TEntidadeDTO entidadeDTO)
        {
            return _service.Incluir(_mapper.Map<TEntidade>(entidadeDTO));
        }

        public TEntidadeDTO SelecionarPorId(int id)
        {
            return _mapper.Map<TEntidadeDTO>(_service.SelecionarPorId(id));
        }

        public IEnumerable<TEntidadeDTO> SelecionarTodos()
        {
            return _mapper.Map<IEnumerable<TEntidadeDTO>>(_service.SelecionarTodos());
        }
    }
}
