namespace FarmaciaApp.Models
{
    public class Productos
    {
        public int id { get; set; }
        public string? nombre { get; set; }
       // public string? descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string? imagenUrl { get; set; } // URL de la imagen del producto 
        public string? categoria { get; set; } // "Medicamento", "Cosmetico", etc.
        public string? marca { get; set; } // Marca del producto
    }
}
