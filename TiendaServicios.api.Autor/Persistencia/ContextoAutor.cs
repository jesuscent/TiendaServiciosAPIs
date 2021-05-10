﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.api.Autor.Modelo;

namespace TiendaServicios.api.Autor.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options)
        { }
        public DbSet<AutorLibro> AutorLibros { get; set; }
        public DbSet<GradoAcademico> GradoAcademicos { get; set; }

    }

}
