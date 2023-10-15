using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Projetos")]
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do projeto é obrigatorio")]
        [Display(Name = "Nome de Projeto")]
        public string nome_projeto { get; set; }

        [Required(ErrorMessage = "A quantidade de colunas é obrigatoria")]
        [Display(Name = "Quantidade de Colunas")]
        public QuantColunas quant_colunas { get; set; }

        [Display(Name = "Usuário")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }

    public enum QuantColunas 
    {
        Tres = 3,
        Quatro = 4,
        Cinco = 5
    }

}
