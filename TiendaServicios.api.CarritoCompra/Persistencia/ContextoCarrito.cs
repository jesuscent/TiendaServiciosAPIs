using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.api.CarritoCompra.Modelo;

namespace TiendaServicios.api.CarritoCompra.Persistencia
{
    public class ContextoCarrito: DbContext
    {
        public ContextoCarrito(DbContextOptions<ContextoCarrito> options): base(options)
        {
                
        }
        public DbSet<CarritoSession> CarritoSession { get; set; }
        public DbSet<CarritoSessionDetalle> CarritoSessionDetalle { get; set; }
    }
}
