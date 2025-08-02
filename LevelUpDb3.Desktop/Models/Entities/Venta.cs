using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpDb3.Desktop.Models.Entities
{
    internal class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public ICollection<VentaDetalle> Conceptos { get; set; } = new List<VentaDetalle>();
    }
}
