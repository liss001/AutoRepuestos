using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class VentaItemRepositorie : IVentaItem
    {
        private readonly AppDbContext _appDbContext;

        public VentaItemRepositorie(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<VentaItem>> All()
        {
            return await _appDbContext.ventaItem.ToListAsync();
        }

        public async Task Crear(VentaItem ventaItem)
        {
            _appDbContext.ventaItem.Add(ventaItem);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<VentaItem> ObtenerId(Guid id)
        {
            var item = await _appDbContext.ventaItem.FirstOrDefaultAsync(v => v.Id == id);
            if (item == null)
                throw new Exception("Detalle de venta no existe");
            return item;
        }


        public async Task Actualizar(VentaItem ventaItem)
        {
            _appDbContext.ventaItem.Update(ventaItem);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
