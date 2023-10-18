using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome de usuário requerido!")]
        [Display(Name = "Nome de Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Email requerido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha requerida!")]
        public string Senha { get; set; }

        public ICollection<Projeto> Projeto { get; set; }
    }

}
