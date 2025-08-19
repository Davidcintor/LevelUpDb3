using LevelUpDb3.Desktop.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

internal class LecturaArchivoTXT
{
    public List<VentaImportDto> LeerArchivo(string rutaArchivo)
    {
        var lineas = File.ReadAllLines(rutaArchivo);
        var ventasDict = new Dictionary<int, VentaImportDto>();

        foreach (var linea in lineas)
        {
            var cols = linea.Split('|');
            try
            {
                int folio = int.Parse(cols[0]);
                DateTime fecha = DateTime.Parse(cols[1]);
                string codCli = cols[2];
                string nombre = cols[3];
                decimal cantidad = decimal.Parse(cols[4]);
                string codProd = cols[5];
                string descripcion = cols[6];
                decimal importe = decimal.Parse(cols[7]);
                decimal subtotal = decimal.Parse(cols[8]);

                var detalle = new VentaDetalleImportDto
                {
                    CodProd = codProd,
                    Descripcion = descripcion,
                    Cantidad = cantidad,
                    Importe = importe,
                    Subtotal = subtotal
                };

                if (!ventasDict.TryGetValue(folio, out var venta))
                {
                    venta = new VentaImportDto
                    {
                        Folio = folio,
                        Fecha = fecha,
                        CodCli = codCli,
                        Nombre = nombre,
                        Productos = new List<VentaDetalleImportDto>()
                    };
                    ventasDict[folio] = venta;
                }
                venta.Productos.Add(detalle);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en línea: '{linea}'. Detalle: {ex.Message}");
            }
        }

        // Calcula el total de cada venta sumando los subtotales de sus productos
        foreach (var venta in ventasDict.Values)
        {
            venta.Total = venta.Productos.Sum(p => p.Subtotal);
        }

        return ventasDict.Values.ToList();
    }
}