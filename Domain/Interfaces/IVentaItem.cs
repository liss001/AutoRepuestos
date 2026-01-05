using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVentaItem
    {
        Task<IEnumerable<VentaItem>> All();
        Task<VentaItem> ObtenerId(Guid id);
        Task Crear(VentaItem ventaItem);
        Task Actualizar(VentaItem ventaItem);
    }
}
