using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.api.Libro.Aplicacion;

namespace TiendaServicios.api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroMaterialDto>>> GetLisbros()
        {
            return await _mediator.Send(new Consulta.Ejecuta());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroMaterialDto>> GetLibroId(Guid id) 
        {
            return await _mediator.Send( new ConsultaFiltro.LibroUnico {LibreriaMateriaId = id });
        }
    }
}
