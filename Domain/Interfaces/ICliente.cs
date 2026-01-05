using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> All();
        Task<Cliente> ObtenerId(Guid id);
        Task Crear(Cliente cliente);
        Task Actualizar(Cliente cliente);
    }
}
