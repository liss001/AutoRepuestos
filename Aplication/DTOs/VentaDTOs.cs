using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class VentaDTOs
    {
        public Guid ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public ICollection<VentaItemDTOs> VentaItems { get; set; }
            = new List<VentaItemDTOs>();
    }
}
