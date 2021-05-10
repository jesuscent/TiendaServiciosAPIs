using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.Autor.Modelo;
using TiendaServicios.api.Autor.Persistencia;

namespace TiendaServicios.api.Autor.Aplicacion
{
    public class Nuevo
    {
        //parte del patron  cqrs
        //clase que recibe los parametro del controlador
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre)
                    .NotEmpty()
                    .WithMessage("El nombre no debe ser vacio")
                    .Length(0,50)
                    .WithMessage("El nombre no debe ser mayor a 50 caracteres "); //que no sea vacio 
                RuleFor(x => x.Apellido).NotEmpty(); //que no sea vacio 
                RuleFor(x => x.Apellido).NotEmpty(); //que no sea vacio 

            }
        }
        //logica de inserción a la bd
        public class Manejador : IRequestHandler<Ejecuta>
        {
            //crear intancia de enttity framework core Context
            public readonly ContextoAutor _contexto;
            //inyecion 
            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //intancias del modelo 
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Convert.ToString(Guid.NewGuid())
                };
                _contexto.AutorLibros.Add(autorLibro);
                //devuelve un valor de confirmcacion si se inserto o no
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;

                }

                throw new Exception("No se puedo insertar el autor del libro");
            }
        }
    }
}
