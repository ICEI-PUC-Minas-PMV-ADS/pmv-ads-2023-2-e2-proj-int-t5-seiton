using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Seiton.Models
{
    [Table("Colunas")]
    public class Colunas
    {
        [Key]
        public int Id { get; set; }

        public string nome_coluna { get; set; }

        public string cor_coluna { get; set; }

        public int quant_tarefas { get; set; }

        public int IdProjeto{ get; set; }

        [ForeignKey("IdProjeto")]
        public Projeto Projeto { get; set; }

        public ICollection<Tarefas> Tarefas { get; set; }

    }
}
