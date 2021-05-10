using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.api.Libro.Modelo
{
    public class LibreriaMaterial
    {
        [Key]
        public Guid? LibreriaMateriaId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? Autorlibro { get; set; }

    }
}
