using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Um nome de usuário é requerido")]
        [Display(Name = "Nome de Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Um email é requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Uma senha é requerida")]
        public string Senha { get; set; }

        public ICollection<Uniao> Unioes { get; set; }
    }
}
