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
        public int quant_colunas { get; set; }
        public Projeto() { quant_colunas = 5; }

        public ICollection<Uniao> Unioes { get; set; }

    }
}
