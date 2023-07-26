using GeekShow.Product.Api.DTOs;
using GeekShow.Product.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GeekShow.Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produto;

        public ProdutosController(IProdutoRepository produto)
        {
            _produto = produto;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public async Task<ActionResult<ICollection<ProdutoDTO>>> Get()
        {
            var list = await _produto.SelectAll();
            if (list is null)
                return NotFound();

            return Ok(list);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Get(Guid id)
        {
            var seek = await _produto.Select(id);
            if (seek is null)
                return NotFound();

            return Ok(seek);
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public async Task<ActionResult> Post(ProdutoDTO produto)
        {
            if (produto is null)
                return Problem(detail: "Produto não pode ser nulo!", statusCode: 400, title: "Insere produto");

            var create = await _produto.Insert(produto);
            return Ok(create);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut]
        public async Task<ActionResult> Put(ProdutoDTO produto)
        {
            if (produto is null)
                return Problem(detail: "Produto não pode ser nulo!", statusCode: 400, title: "Atualiza produto");

            var atualiza = await _produto.Update(produto);
            return Ok(atualiza);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var isDeleted = await _produto.Delete(id);
            if (!isDeleted)
                return Problem(detail: "Produto não existe!", statusCode: 400, title: "Remove produto");

            return Ok(isDeleted);
        }
    }
}
