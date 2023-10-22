using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Tarefas")]
    public class Tarefas
    {
        [Key]
        public int Id { get; set; }

        public string nome_tarefas { get; set; }

        public string descricao { get; set;}

        public int prioridade { get; set; }

        public string responsavel { get; set; }

        public int IdColuna { get; set; }

        [ForeignKey("IdColuna")]
        public Colunas Colunas { get; set; }
    }
}
