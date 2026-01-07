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
            if (ventaItem == null)
                throw new ArgumentException("El detalle de venta es obligatorio");

            if (ventaItem.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0");

            if (ventaItem.PrecioUnitario <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor a 0");

            ventaItem.SubTotal = ventaItem.Cantidad * ventaItem.PrecioUnitario;

            await _ventaItem.Crear(ventaItem);
        }
    }
}
