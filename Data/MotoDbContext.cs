using Microsoft.EntityFrameworkCore;
using Mottu.Models;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
namespace Mottu.Data
{
    public class MotoDbContext : DbContext
    {
        public MotoDbContext(DbContextOptions<MotoDbContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Leitura> Leituras { get; set; }
    }
}

