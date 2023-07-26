namespace GeekShow.Product.Api.Entities.ProdutoContext
{
    public class Produto : BaseEntity
    {

        public Produto(DateTime? updateAt, string nome, decimal preco, string descricao, string categoria, string imgUrl) : base(updateAt)
        {
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Categoria = categoria;
            ImgUrl = imgUrl;
        }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ImgUrl { get; set; }
    }
}
