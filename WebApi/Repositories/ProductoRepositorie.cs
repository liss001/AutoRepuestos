using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class ProductoRepositorie : IProducto
    {
        private readonly AppDbContext _appDbContext;

        public ProductoRepositorie(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Producto>> All()
        {
            return await _appDbContext.producto.ToListAsync();
        }

        public async Task Crear(Producto producto)
        {
            _appDbContext.producto.Add(producto);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Producto> ObtenerId(Guid id)
        {
            var producto = await _appDbContext.producto
                                              .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
                throw new Exception("El producto no existe");

            return producto;
        }


        public async Task Actualizar(Producto producto)
        {
            _appDbContext.producto.Update(producto);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
