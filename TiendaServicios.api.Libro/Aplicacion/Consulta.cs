using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.Libro.Modelo;
using TiendaServicios.api.Libro.Persistencia;

namespace TiendaServicios.api.Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta: IRequest<List<LibroMaterialDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDto>>
        {
            public readonly ContextoLibreria _contexto;
            public readonly IMapper _mapper;
            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;

            }
            public async Task<List<LibroMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var listLibro = await _contexto.LibreriaMaterial.ToListAsync();
                //primer datos es el origen, el segundo a que se convierte
               var ListLibroDto = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(listLibro);

                return ListLibroDto;
            }
        }
    }
}
