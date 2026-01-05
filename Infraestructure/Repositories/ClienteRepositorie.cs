using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class ClienteRepositorie : ICliente
    {
        private readonly AppDbContext _appDbContext;

        public ClienteRepositorie(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Cliente>> All()
        {
            return await _appDbContext.cliente.ToListAsync();
        }

        public async Task Crear(Cliente cliente)
        {
            _appDbContext.cliente.Add(cliente);
            await _appDbContext.SaveChangesAsync();
        }

        public Task<Cliente> ObtenerId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Actualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
