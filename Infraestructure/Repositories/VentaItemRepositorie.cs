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

        public Task<VentaItem> ObtenerId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Actualizar(VentaItem ventaItem)
        {
            throw new NotImplementedException();
        }
    }
}
