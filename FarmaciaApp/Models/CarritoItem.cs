namespace FarmaciaApp.Models
{
    public class CarritoItem
    {
        public int productoId { get; set; }
        public string? nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
    }
}

