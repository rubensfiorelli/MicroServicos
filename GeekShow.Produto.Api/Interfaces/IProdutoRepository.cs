using GeekShow.Product.Api.DTOs;

namespace GeekShow.Product.Api.Interfaces
{
    public interface IProdutoRepository
    {
        Task<ICollection<ProdutoDTO>> SelectAll();
        Task<ProdutoDTO> Select(Guid id);
        Task<ProdutoDTO> Insert(ProdutoDTO produto);
        Task<ProdutoDTO> Update(ProdutoDTO produto);
        Task<bool> Delete(Guid id);
    }
}
