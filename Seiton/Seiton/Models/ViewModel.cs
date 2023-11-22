namespace Seiton.Models
{
    public class ViewModel
    {
        // Projetos
        public List<string> Nome_projeto { get; set; }
        public List<int> ProjetoId { get; set; }

        // Colunas
        public List<string> NomeColuna { get; set; }
        public List<int> IdColuna { get; set; }
        public List<string> CorColuna { get; set; }

        // Tarefas
        public List<int> ID { get; set; }
        public List<int> IdTarefa { get; set; }
        public List<int> Prioridade { get; set; }
        public List<string> NomeTarefas { get; set; }
        public List<string> descricao { get; set; }
        public List<string> Responsavel { get; set; }
        public List<int> IdColunaFK { get; set; }

    }
}
