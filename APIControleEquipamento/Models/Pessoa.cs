using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIControleEquipamento.Models
{
    [Table("Pessoas")]
    public class Pessoa
    {
        public Pessoa()
        {
            Cautelas = new Collection<Cautela>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string TipoPessoa { get; set; }
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Matricula { get; set; }
        public ICollection<Cautela> Cautelas { get; set; }
        
    }
}
