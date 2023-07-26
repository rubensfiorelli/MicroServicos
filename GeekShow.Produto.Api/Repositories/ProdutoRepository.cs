using AutoMapper;
using GeekShow.Product.Api.Context;
using GeekShow.Product.Api.DTOs;
using GeekShow.Product.Api.Entities.ProdutoContext;
using GeekShow.Product.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShow.Product.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProdutoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> Insert(ProdutoDTO produto)
        {
            try
            {
                var entity = _mapper.Map<Produto>(produto);

                _context.Produtos.Add(entity);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProdutoDTO>(entity);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO> Update(ProdutoDTO produto)
        {
            try
            {

                var entity = _mapper.Map<Produto>(produto);

                _context.Produtos.Update(entity);

                await _context.SaveChangesAsync();

                return _mapper.Map<ProdutoDTO>(entity);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var produto = await _context.Produtos.Where(p => p.Id.Equals(id))
                   .FirstOrDefaultAsync();

                if (produto is null)
                    return false;

                _context.Produtos.Remove(produto);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO> Select(Guid id)
        {
            try
            {
                var produto = await _context.Produtos.Where(p => p.Id.Equals(id))
                    .FirstOrDefaultAsync();
                return _mapper.Map<ProdutoDTO>(produto);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<ProdutoDTO>> SelectAll()
        {
            try
            {
                var produtos = await _context.Produtos.ToListAsync();
                return _mapper.Map<List<ProdutoDTO>>(produtos);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
