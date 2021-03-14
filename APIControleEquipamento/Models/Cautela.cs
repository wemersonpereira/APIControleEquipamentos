using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIControleEquipamento.Models
{
    [Table("Cautelas")]
    public class Cautela
    {
        public Cautela()
        {
            Equipamentos = new Collection<Equipamento>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Descrição { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public ICollection<Equipamento> Equipamentos { get; set; }
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
    }
}
