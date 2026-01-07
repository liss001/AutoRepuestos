using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaItemController : ControllerBase
    {
        private readonly IVentaItem _ventaItem;
        private readonly IMapper _mapper;
        private readonly CrearVentaItem _crearVentaItem;

        public VentaItemController(
            IVentaItem ventaItem,
            IMapper mapper,
            CrearVentaItem crearVentaItem)
        {
            _ventaItem = ventaItem;
            _mapper = mapper;
            _crearVentaItem = crearVentaItem;
        }

        // GET: api/VentaItem
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _ventaItem.All();

            if (!items.Any())
                return NotFound("No hay detalles de venta");

            var itemsDto = _mapper.Map<IEnumerable<VentaItemDTOs>>(items);
            return Ok(itemsDto);
        }

        // GET: api/VentaItem/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var itemEntity = await _ventaItem.ObtenerId(id);

            if (itemEntity == null)
                return NotFound("Detalle de venta no encontrado");

            var itemDto = _mapper.Map<VentaItemDTOs>(itemEntity);
            return Ok(itemDto);
        }

        // POST: api/VentaItem
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VentaItemDTOs ventaItemDTO)
        {
            try
            {
                var itemEntity = _mapper.Map<VentaItem>(ventaItemDTO);

                await _crearVentaItem.EjecutarAsync(itemEntity);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = itemEntity.Id },
                    ventaItemDTO
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
