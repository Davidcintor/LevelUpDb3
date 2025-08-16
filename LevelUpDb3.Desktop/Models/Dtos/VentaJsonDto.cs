using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUpDb3.Desktop.Models.Entities;

namespace LevelUpDb3.Desktop.Models.Dtos
{
    public class VentaJsonDto
    {
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string CodCli { get; set; }
        public string Nombre { get; set; }

        public List<VentaDetalleJsonDto> Productos { get; set; } = new List<VentaDetalleJsonDto>();
    }
}
