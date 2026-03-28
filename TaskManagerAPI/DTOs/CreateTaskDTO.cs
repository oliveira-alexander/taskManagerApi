using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskManagerAPI.DTOs
{
    public class CreateTaskDTO
    {
        [Required(ErrorMessage = "Informe um título!")]
        [NotNull]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O tamanho mínimo para o título é 3 caracteres!")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Informe a descrição!")]
        [NotNull]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O tamanho mínimo para descrição é 5 caracteres!")]
        public string Description { get; set; } = "";
    }
}
