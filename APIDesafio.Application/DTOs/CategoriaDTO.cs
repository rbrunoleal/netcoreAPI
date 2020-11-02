using System.ComponentModel.DataAnnotations;

namespace APIDesafio.Application.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição é um campo obrigatório.")]
        public string Descricao { get; set; }
    }
}
