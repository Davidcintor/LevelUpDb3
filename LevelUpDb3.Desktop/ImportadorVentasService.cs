using LevelUpDb3.Desktop.Models.Dtos;
using LevelUpDb3.Desktop.Models.Entities;
using Microsoft.EntityFrameworkCore;

internal class ImportadorVentasService
{
    public async Task ImportarVentasAsync(List<VentaImportDto> ventasDtos)
    {
        using var context = new LevelUpDb3.Desktop.Models.ApplicationDbContext();
        using var transaccion = await context.Database.BeginTransactionAsync();

        var clientesCache = context.Clientes.ToDictionary(c => c.Codigo);
        var productosCache = context.Productos.ToDictionary(p => p.Codigo);

        try
        {
            foreach (var dto in ventasDtos)
            {
                if (!clientesCache.TryGetValue(dto.CodCli, out var cliente))
                {
                    cliente = new Cliente { Codigo = dto.CodCli, Nombre = dto.Nombre };
                    context.Clientes.Add(cliente);
                    context.SaveChanges();
                    clientesCache[cliente.Codigo] = cliente;
                }

                if (context.Ventas.Any(v => v.Folio == dto.Folio))
                    continue;

                var venta = new Venta
                {
                    Folio = dto.Folio,
                    Fecha = dto.Fecha,
                    Total = dto.Total,
                    ClienteId = cliente.Id
                };
                context.Ventas.Add(venta);
                context.SaveChanges();

                foreach (var det in dto.Productos)
                {
                    if (!productosCache.TryGetValue(det.CodProd, out var producto))
                    {
                        producto = new Producto
                        {
                            Codigo = det.CodProd,
                            Descripcion = det.Descripcion,
                            ValorUnitario = det.Cantidad > 0 ? det.Importe / det.Cantidad : 0,
                            FechaCreacion = DateTime.Now
                        };
                        context.Productos.Add(producto);
                        context.SaveChanges();
                        productosCache[producto.Codigo] = producto;
                    }

                    var ventaDet = new VentaDetalle
                    {
                        VentaId = venta.Id,
                        ProductoId = producto.Id,
                        Cantidad = det.Cantidad,
                        Importe = det.Importe,
                        ValorUnitario = producto.ValorUnitario
                    };
                    context.VentaDetalles.Add(ventaDet);
                }
                context.SaveChanges();
            }

            await transaccion.CommitAsync();
        }
        catch (Exception ex)
        {
            // Solo relanza la excepción, no muestres MessageBox aquí
            throw new Exception("Error en importación: " + ex.Message, ex);
        }
    }
}