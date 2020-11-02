using APIDesafio.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace APIDesafio.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição é um campo obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Valor é um campo obrigatório.")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Quantidade é um campo obrigatório.")]
        public int Quantidade { get; set; }
        
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
