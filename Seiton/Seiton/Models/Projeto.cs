using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Seiton.Models
{
    [Table("Projetos")]
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do projeto é obrigatorio!")]
        [Display(Name = "Nome de Projeto:")]
        public string nome_projeto { get; set; }

        [Display(Name = "Quantidade de Colunas:")]
        public int quant_colunas { get; set; }
        public Projeto() { quant_colunas = 5; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public ICollection<Colunas> Colunas { get; set; }
    }

}