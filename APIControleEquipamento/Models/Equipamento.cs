using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIControleEquipamento.Models
{
    [Table("Equipamentos")]
    public class Equipamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string TipoEquipamento { get; set; }
        [Required]
        [MaxLength(80)]
        public string Marca { get; set; }
        [Required]
        [MaxLength(80)]
        public string Modelo { get; set; }
        [Required]
        [MaxLength(80)]
        public string NumeroControle { get; set; }
    }
}
