using System.ComponentModel;
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

        [Required(ErrorMessage = "*Informe o nome da tarefa!")]
        [DisplayName("Nome da Tarefa:")]
        public string nome_tarefas { get; set; }

        [DisplayName("Descrição:")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "*Informe a prioridade!")]
        [DisplayName("Prioridade:")]
        public int prioridade { get; set; }

        [DisplayName("Responsável:")]
        public string responsavel { get; set; }

        [DisplayName("Coluna:")]
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
