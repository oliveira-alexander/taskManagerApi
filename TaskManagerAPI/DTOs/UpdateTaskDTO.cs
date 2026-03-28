using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DTOs
{
    public class UpdateTaskDTO
    {
        [Required(ErrorMessage = "Informe o ID da tarefa!")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe um título!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O tamanho mínimo para o título é 3 caracteres!")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Informe a descrição!")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O tamanho mínimo para descrição é 5 caracteres!")]
        public string Description { get; set; } = "";
    }
}
