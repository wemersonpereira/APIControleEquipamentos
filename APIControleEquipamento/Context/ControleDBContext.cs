using APIControleEquipamento.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIControleEquipamento.Context
{
    public class ControleDBContext : DbContext
    {
        public ControleDBContext(DbContextOptions<ControleDBContext> options)
            : base(options)
        { }

        public DbSet<Cautela> Cautelas { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
