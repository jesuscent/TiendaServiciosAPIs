using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.Autor.Modelo;
using TiendaServicios.api.Autor.Persistencia;

namespace TiendaServicios.api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }
        //AutorUnico es la clase 
        //el segundo el tipo de datos que pasa 

        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            public readonly ContextoAutor _contexto;
            public readonly IMapper _mapper;
            public Manejador(ContextoAutor contexto,IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibros.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
               
                if (autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                var autorDto = _mapper.Map<AutorLibro, AutorDto>(autor);
                return autorDto;
            }
        }

        //public class AutorUnico : IRequest<AutorLibro>
        //{
        //    public string AutorGuid { get; set; }
        //}
        ////AutorUnico es la clase 
        ////el segundo el tipo de datos que pasa 

        //public class Manejador : IRequestHandler<AutorUnico, AutorLibro>
        //{
        //    public readonly ContextoAutor _contexto;
        //    public readonly IMapper _mapper;
        //    public Manejador(ContextoAutor contexto, IMapper mapper)
        //    {
        //        _contexto = contexto;
        //        _mapper = mapper;
        //    }

        //    public async Task<AutorLibro> Handle(AutorUnico request, CancellationToken cancellationToken)
        //    {
        //        var autor = await _contexto.AutorLibros.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
        //        if (autor == null)
        //        {
        //            throw new Exception("No se encontro el autor");
        //        }
        //        return autor;
        //    }
        //}
    }
}
