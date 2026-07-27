using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Gestión_de_Productos.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250)]
        public string Descripcion { get; set; }    

        [Required(ErrorMessage ="El precio es obligatorio.")]
        [Range(0.01,9999999,ErrorMessage ="El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage ="La cantidad es obligatoria")]
        [Range(0,999999,ErrorMessage ="La cantidad no puede ser negativa")]
        public int Cantidad { get; set; }

        public DateTime CreacionFecha { get; set; } = DateTime.Now;
    }
}
