using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class CrearCliente
    {
        private readonly ICliente _cliente;

        public CrearCliente(ICliente cliente)
        {
            _cliente = cliente;
        }

        public async Task EjecutarAsync(Cliente cliente)
        {
            ValidarCliente(cliente);
            await _cliente.Crear(cliente);
        }

        public void ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("Existe un error en el nombre");

            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new ArgumentException("Existe un error en el teléfono");

            if (string.IsNullOrWhiteSpace(cliente.CorreoElectronico))
                throw new ArgumentException("Existe un error en el correo electrónico");
        }
    }
}
