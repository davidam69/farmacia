namespace FarmaciaApp.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? email { get; set; }
        public string? passwordHash { get; set; }
        public string? rol { get; set; } // "Usuario" o "Admin"
    }
}
