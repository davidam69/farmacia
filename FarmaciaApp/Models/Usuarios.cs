using CsvHelper.Configuration.Attributes;

namespace FarmaciaApp.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        [Required]
        public string? nombre { get; set; }
        [Required, EmailAddress]
        public string? email { get; set; }
        [Required]
        public string? passwordHash { get; set; }
        [Ignore]
        [Required, Compare("passwordHash", ErrorMessage = "Las contraseñas no coinciden.")]
        public string? confirmPassword { get; set; }
        public string? rol { get; set; } = "cliente"; // "Cliente" o "Admin"
    }
}
