namespace LevelUpDb3.Desktop.Models.Entities
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
