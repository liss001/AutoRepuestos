using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVenta venta;
        private readonly IMapper _mapper;
        private readonly CrearVenta _crearVenta;

        public VentaController(IVenta venta, IMapper mapper, CrearVenta crearVenta)
        {
            this.venta = venta;
            _mapper = mapper;
            _crearVenta = crearVenta;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ventas = await venta.All();
            if (!ventas.Any())
                return NotFound("No hay ventas registradas");

            var ventasDto = _mapper.Map<IEnumerable<VentaDTOs>>(ventas);
            return Ok(ventasDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ventaEntity = await venta.ObtenerId(id);
            if (ventaEntity == null)
                return NotFound("Venta no encontrada");

            var ventaDto = _mapper.Map<VentaDTOs>(ventaEntity);
            return Ok(ventaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VentaDTOs ventaDTO)
        {
            try
            {
                var ventaEntity = _mapper.Map<Venta>(ventaDTO);
                await _crearVenta.EjecutarAsync(ventaEntity);

                return CreatedAtAction(nameof(GetById),
                    new { id = ventaEntity.Id }, ventaDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
