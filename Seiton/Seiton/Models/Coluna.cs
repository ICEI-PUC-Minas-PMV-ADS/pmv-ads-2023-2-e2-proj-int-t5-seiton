using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Seiton.Models
{
    [Table("Coluna")]
    public class Coluna
    {
        [Key]
        public int Id { get; set; }

        public string nome_coluna { get; set; }

        [Display(Name = "Cor da Coluna")]
        public CoresColuna cor_coluna { get; set; }
       
        public int quant_tarefas { get; set; }
        
        public int IdProjeto{ get; set; }

        [ForeignKey("IdProjeto")]
        public Projeto Projeto { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }

    public enum CoresColuna
    {
        Azul = 1,
        Verde = 2,
        Vermelho = 3,
        Laranja = 4,
        Roxo = 5
    }
}
