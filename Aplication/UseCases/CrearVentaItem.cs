using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class CrearVentaItem
    {
        private readonly IVentaItem _ventaItem;

        public CrearVentaItem(IVentaItem ventaItem)
        {
            _ventaItem = ventaItem;
        }

        public async Task EjecutarAsync(VentaItem ventaItem)
        {
            ValidarVentaItem(ventaItem);
            await _ventaItem.Crear(ventaItem);
        }

        public void ValidarVentaItem(VentaItem ventaItem)
        {
            if (ventaItem.ProductoId == Guid.Empty)
                throw new ArgumentException("El producto es obligatorio");

            if (ventaItem.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero");

            if (ventaItem.PrecioUnitario <= 0)
                throw new ArgumentException("El precio unitario es inválido");
        }
    }
}
