using Microsoft.EntityFrameworkCore;
namespace Mottu.Models
{
    public class Leitura
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Sensor { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;

        public int MotoId { get; set; }
        public Moto Moto { get; set; }
    }
}