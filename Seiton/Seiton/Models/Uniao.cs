using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seiton.Models
{
    [Table("Unioes")]
    public class Uniao
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public int IdProjeto { get; set; }

        [ForeignKey("IdProjeto")]
        public Projeto Projeto { get; set; }
    }

}
