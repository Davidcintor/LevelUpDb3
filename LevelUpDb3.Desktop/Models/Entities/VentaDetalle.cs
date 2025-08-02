namespace LevelUpDb3.Desktop.Models.Entities
{
    internal class VentaDetalle
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public Venta Venta { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
    }
}
