using DDDTreino.Aplicao.DTO;
using DDDTreino.Dominio.Entidades;

namespace DDDTreino.Aplicao.Interfaces
{
    public interface IAppBase<TEntidade, TEntidadeDTO> where TEntidade : EntidadeBase
        where TEntidadeDTO : BaseDTO
    {
        int Incluir(TEntidadeDTO entidadeDTO);
        void Excluir(TEntidadeDTO entidadeDTO);
        void Excluir(int id);
        void Alterar(TEntidadeDTO entidadeDTO);
        TEntidadeDTO SelecionarPorId(int id);
        IEnumerable<TEntidadeDTO> SelecionarTodos();
    }
}
