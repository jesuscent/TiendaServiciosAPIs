using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.CarritoCompra.Modelo;
using TiendaServicios.api.CarritoCompra.Persistencia;

namespace TiendaServicios.api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ProductoLista { get; set; }

        }
        public class Manejador : IRequestHandler<ejecuta>
        {
            private readonly ContextoCarrito _context;
            public Manejador(ContextoCarrito contexto)
            {
                _context = contexto;
            }
            public async Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {

                var carritoSesion = new CarritoSession
                {
                    FechaCreacion = request.FechaCreacionSesion
                };

                _context.CarritoSession.Add(carritoSesion);
                var valor = await _context.SaveChangesAsync();
                if (valor==0)
                {
                    throw new Exception("No se puedo insertar carrito sesion");
                }

                int id = carritoSesion.CarritoSessionId;
                foreach(var obj in request.ProductoLista)
                {
                    var detalle = new CarritoSessionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = obj
                    };
                    _context.CarritoSessionDetalle.Add(detalle);
                    
                }
                valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se puedo insertar  el carrito detalle");

            }
        }
    }
}
