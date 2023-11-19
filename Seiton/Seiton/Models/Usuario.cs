using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Informe um nome de usuário!")]
        [Display(Name = "Nome de Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "*Informe um Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Informe uma senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        //[Required(ErrorMessage = "Repita a senha novamente!")]
        // public string ConfirmarSenha { get; set; }


        [Required(ErrorMessage = "*Informe a confirmação de senha!")]
        [Compare("Senha", ErrorMessage = "*As senhas não coincidem.")]
        [Display(Name = "Confirme a Senha")]
        [DataType(DataType.Password)]
        [NotMapped] // Isso evita que o campo seja mapeado para o banco de dados.
        public string ConfirmacaoSenha { get; set; }


        public ICollection<Projeto> Projeto { get; set; }




    }

}
