using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        public string nome_tarefas { get; set; }

        public string descricao { get; set;}

        [Display(Name = "Prioridade")]
        public CoresPrioridade prioridade { get; set; }

        public string responsavel { get; set; }

        public int IdColuna { get; set; }

        [ForeignKey("IdColuna")]
        public Coluna Colunas { get; set; }
    }

    public enum CoresPrioridade
    {
        Alta = 1,
        Média = 2,
        Baixa = 3
    }
}
