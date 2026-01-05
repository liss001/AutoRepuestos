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
    public class ProductoController : ControllerBase
    {
        private readonly IProducto producto;
        private readonly IMapper _mapper;
        private readonly CrearProducto _crearProducto;

        public ProductoController(IProducto producto, IMapper mapper, CrearProducto crearProducto)
        {
            this.producto = producto;
            _mapper = mapper;
            _crearProducto = crearProducto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await producto.All();
            if (!productos.Any())
                return NotFound("No hay productos que listar");

            var productosDto = _mapper.Map<IEnumerable<ProductoDTOs>>(productos);
            return Ok(productosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var productoEntity = await producto.ObtenerId(id);
            if (productoEntity == null)
                return NotFound("Producto no encontrado");

            var productoDto = _mapper.Map<ProductoDTOs>(productoEntity);
            return Ok(productoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoDTOs productoDTO)
        {
            try
            {
                var productoEntity = _mapper.Map<Producto>(productoDTO);
                await _crearProducto.EjecutarAsync(productoEntity);

                return CreatedAtAction(nameof(GetById),
                    new { id = productoEntity.Id }, productoDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
