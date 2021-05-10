using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.Libro.Modelo;
using TiendaServicios.api.Libro.Persistencia;

namespace TiendaServicios.api.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid? LibreriaMateriaId { get; set; }
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid? Autorlibro { get; set; }
        }

        public class EjecutaValidacion: AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty().Length(0, 100);
                RuleFor(x=>x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.Autorlibro).NotEmpty();
            }

        }

        public class Manejador : IRequestHandler<Ejecuta>
        {

            public readonly ContextoLibreria _contexto;
            public Manejador(ContextoLibreria contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = new LibreriaMaterial
                {
                    Titulo = request.Titulo,
                    FechaPublicacion= request.FechaPublicacion,
                    Autorlibro =request.Autorlibro

                };
                _contexto.Add(libro);
               var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo Guardar el libro");
            }
        }
    }
}
