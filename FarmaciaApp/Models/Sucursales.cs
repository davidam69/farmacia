namespace FarmaciaApp.Models
{
    public class Sucursal
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }

}
