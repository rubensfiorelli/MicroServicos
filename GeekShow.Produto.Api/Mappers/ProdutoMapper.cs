using AutoMapper;
using GeekShow.Product.Api.DTOs;
using GeekShow.Product.Api.Entities.ProdutoContext;

namespace GeekShow.Product.Api.Mappers
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ReverseMap();
        }
    }
}
