using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUpDb3.Desktop.Models.Dtos;
using System.Text.Json;

namespace LevelUpDb3.Desktop
{
    internal class LecturaArchivoJSON
    {
        public List<VentaImportDto> LeerArchivo(string rutaArchivo)
        {
            string jsonString = File.ReadAllText(rutaArchivo);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<VentaImportDto>? ventas = 
                JsonSerializer.Deserialize<List<VentaImportDto>>(jsonString, options);
        
            return ventas ?? new List<VentaImportDto>();
        }
    }
}
