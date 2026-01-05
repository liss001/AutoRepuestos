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
    public class VentaItemController : ControllerBase
    {
        private readonly IVentaItem ventaItem;
        private readonly IMapper _mapper;
        private readonly CrearVentaItem _crearVentaItem;

        public VentaItemController(
            IVentaItem ventaItem,
            IMapper mapper,
            CrearVentaItem crearVentaItem)
        {
            this.ventaItem = ventaItem;
            _mapper = mapper;
            _crearVentaItem = crearVentaItem;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await ventaItem.All();
            if (!items.Any())
                return NotFound("No hay detalles de venta");

            var itemsDto = _mapper.Map<IEnumerable<VentaItemDTOs>>(items);
            return Ok(itemsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var itemEntity = await ventaItem.ObtenerId(id);
            if (itemEntity == null)
                return NotFound("Detalle de venta no encontrado");

            var itemDto = _mapper.Map<VentaItemDTOs>(itemEntity);
            return Ok(itemDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VentaItemDTOs ventaItemDTO)
        {
            try
            {
                var itemEntity = _mapper.Map<VentaItem>(ventaItemDTO);
                await _crearVentaItem.EjecutarAsync(itemEntity);

                return CreatedAtAction(nameof(GetById),
                    new { id = itemEntity.Id }, ventaItemDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
