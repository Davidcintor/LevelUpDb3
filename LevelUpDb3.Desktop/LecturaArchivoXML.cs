using System.Xml.Linq;
using LevelUpDb3.Desktop.Models.Dtos;

internal class LecturaArchivoXML
{
    public List<VentaImportDto> LeerArchivo(string rutaArchivo)
    {
        var doc = XDocument.Load(rutaArchivo);
        var ventas = new List<VentaImportDto>();

        foreach (var ventaElem in doc.Descendants("Venta"))
        {
            var venta = new VentaImportDto
            {
                Folio = int.Parse(ventaElem.Element("Folio")?.Value ?? "0"),
                Fecha = DateTime.Parse(ventaElem.Element("Fecha")?.Value ?? DateTime.MinValue.ToString()),
                Total = decimal.Parse(ventaElem.Element("Total")?.Value ?? "0"),
                CodCli = ventaElem.Element("CodCli")?.Value ?? "",
                Nombre = ventaElem.Element("Nombre")?.Value ?? ""
            };

            foreach (var prodElem in ventaElem.Descendants("Producto"))
            {
                var detalle = new VentaDetalleImportDto
                {
                    CodProd = prodElem.Element("CodProd")?.Value ?? "",
                    Descripcion = prodElem.Element("Descripcion")?.Value ?? "",
                    Cantidad = decimal.Parse(prodElem.Element("Cantidad")?.Value ?? "0"),
                    Importe = decimal.Parse(prodElem.Element("Importe")?.Value ?? "0"),
                    Subtotal = decimal.Parse(prodElem.Element("Subtotal")?.Value ?? "0")
                };
                venta.Productos.Add(detalle);
            }
            ventas.Add(venta);
        }
        return ventas;
    }
}