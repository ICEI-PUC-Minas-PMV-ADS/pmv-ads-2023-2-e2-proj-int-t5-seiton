using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System;
using System.ComponentModel;

namespace Seiton.Models
{
    [Table("Colunas")]
    public class Colunas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Informe um nome para a coluna!")]
        [DisplayName("Nome da Coluna:")]
        public string nome_coluna { get; set; }

        [Required(ErrorMessage = "*Informe uma cor para a coluna!")]
        [DisplayName("Cor da coluna:")]
        public string cor_coluna { get; set; }

        [DisplayName("Quantidade de tarefas:")]
        public int quant_tarefas { get; set; }

        public int IdProjeto{ get; set; }

        [ForeignKey("IdProjeto")]
        public Projeto Projeto { get; set; }

        public ICollection<Tarefas> Tarefas { get; set; }

    }
    public class cores
    {
        public const string ArgentinianBlue = "#4EAAFF";
        public const string Folly = "#FF4167";
        public const string HunyadiYellow = "#FFB64F";
        public const string DimGray = "#696969";
        public const string LimeGreen = "#37C936";
    }
}
