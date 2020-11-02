namespace APIDesafio.Domain.Entity
{
    public class Produto : Base
    {
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
