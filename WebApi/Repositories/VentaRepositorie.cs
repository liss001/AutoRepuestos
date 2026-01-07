using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class VentaRepositorie : IVenta
    {
        private readonly AppDbContext _appDbContext;

        public VentaRepositorie(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Venta>> All()
        {
            return await _appDbContext.venta
                .Include(v => v.VentaItems)
                .ToListAsync();
        }

        public async Task Crear(Venta venta)
        {
            _appDbContext.venta.Add(venta);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Venta> ObtenerId(Guid id)
        {
            var item = await _appDbContext.venta.FirstOrDefaultAsync(v => v.Id == id);
            if (item == null)
                throw new Exception("Venta no existe");
            return item;
        }
        public async Task Actualizar(Venta venta)
        {
            _appDbContext.venta.Update(venta);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
