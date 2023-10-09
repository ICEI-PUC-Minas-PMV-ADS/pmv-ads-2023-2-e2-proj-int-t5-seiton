using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Projeto")]
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo IdProjeto é obrigatorio")]

        public string IdProjeto { get; set; }

        [Required(ErrorMessage = "O campo Nome_Projeto é obrigatorio")]
        public string nome_projeto { get; set; }

        [Required(ErrorMessage = "O campo quant_Colunas é obrigatorio")]
        public string quant_colunas { get; set; }

        [ForeignKey("Usuarios")]
        public int id { get; set; }


    }

}



