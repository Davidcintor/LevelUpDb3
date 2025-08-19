using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpDb3.Desktop.Models.Dtos
{
    public class VentaDetalleImportDto
    {
        public string CodProd { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal Subtotal { get; set; }
    }
}
