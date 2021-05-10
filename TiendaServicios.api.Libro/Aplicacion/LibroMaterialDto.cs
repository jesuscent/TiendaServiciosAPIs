using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.api.Libro.Aplicacion
{
    public class LibroMaterialDto
    {
        public Guid? LibreriaMateriaId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? Autorlibro { get; set; }
    }
}
