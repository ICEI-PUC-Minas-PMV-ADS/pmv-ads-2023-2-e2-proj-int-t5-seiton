using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um usuário")]
        [Display(Name = "Nome de Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Um email é requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira uma senha")]
        public string Senha { get; set; }

        public ICollection<Projeto> Projetos { get; set; }
    }
}
