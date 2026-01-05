using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class CrearProducto
    {
        private readonly IProducto _producto;

        public CrearProducto(IProducto producto)
        {
            _producto = producto;
        }

        public async Task EjecutarAsync(Producto producto)
        {
            ValidarProducto(producto);
            await _producto.Crear(producto);
        }

        public void ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("Existe un error en el nombre");

            if (producto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            if (producto.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo");
        }
    }
}
