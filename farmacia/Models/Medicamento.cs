// Models/Medicamento.cs
using System.ComponentModel.DataAnnotations;

namespace FarmaciaApp.Models
{
    public class Medicamento
    {
        public int id { get; set; }

        [Required]
        public string? nombre { get; set; }

        [Range(0, 100000)]
        public decimal precio { get; set; }

        [Range(0, 1000)]
        public int stock { get; set; }
    }
}
