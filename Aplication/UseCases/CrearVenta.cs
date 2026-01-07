using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class CrearVenta
    {
        private readonly IVenta _venta;
        private readonly IProducto _producto;

        public CrearVenta(IVenta venta, IProducto producto)
        {
            _venta = venta;
            _producto = producto;
        }

        public async Task EjecutarAsync(Venta venta)
        {
            ValidarVenta(venta);

            decimal total = 0;

            // Verificar stock y descontar
            foreach (var item in venta.VentaItems)
            {
                var producto = await _producto.ObtenerId(item.ProductoId);

                if (producto == null)
                    throw new ArgumentException("Producto no encontrado");

                if (producto.Stock < item.Cantidad)
                    throw new ArgumentException($"Stock insuficiente para el producto {producto.Nombre}");

                // Descontar 
                producto.Stock -= item.Cantidad;
                await _producto.Actualizar(producto);

                // subtotal
                item.PrecioUnitario = producto.Precio;
                item.SubTotal = item.Cantidad * producto.Precio;

                total += item.SubTotal;
            }

            
            venta.Total = total;
            venta.Fecha = DateTime.Now;

            
            await _venta.Crear(venta);
        }

        private void ValidarVenta(Venta venta)
        {
            if (venta.ClienteId == Guid.Empty)
                throw new ArgumentException("El cliente es obligatorio");

            if (venta.VentaItems == null || !venta.VentaItems.Any())
                throw new ArgumentException("La venta debe tener al menos un producto");
        }
    }
}
