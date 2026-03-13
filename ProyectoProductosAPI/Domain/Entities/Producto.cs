using System.ComponentModel.DataAnnotations;

namespace ProyectoProductosAPI.Domain.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
}

