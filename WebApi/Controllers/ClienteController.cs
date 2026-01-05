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
    public class ClienteController : ControllerBase
    {
        private readonly ICliente cliente;
        private readonly IMapper _mapper;
        private readonly CrearCliente _crearCliente;

        public ClienteController(ICliente cliente, IMapper mapper, CrearCliente crearCliente)
        {
            this.cliente = cliente;
            _mapper = mapper;
            _crearCliente = crearCliente;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await cliente.All();
            if (!clientes.Any())
                return NotFound("No hay clientes que listar");

            var clientesDto = _mapper.Map<IEnumerable<ClienteDTOs>>(clientes);
            return Ok(clientesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var clienteEntity = await cliente.ObtenerId(id);
            if (clienteEntity == null)
                return NotFound("Cliente no encontrado");

            var clienteDto = _mapper.Map<ClienteDTOs>(clienteEntity);
            return Ok(clienteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDTOs clienteDTO)
        {
            try
            {
                var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
                await _crearCliente.EjecutarAsync(clienteEntity);

                return CreatedAtAction(nameof(GetById),
                    new { id = clienteEntity.Id }, clienteDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
