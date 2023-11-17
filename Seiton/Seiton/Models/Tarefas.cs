using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Tarefas")]
    public class Tarefas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string nome_tarefas { get; set; }

        public string descricao { get; set; }

        public int prioridade { get; set; }

        public string responsavel { get; set; }

        public int IdColuna { get; set; }

        [ForeignKey("IdColuna")]
        public Colunas Colunas { get; set; }

    }
    public class prioridadeOp
    {

        public const int Alta = 3;
        public const int Média = 2;
        public const int Baixa = 1;

    }
}
