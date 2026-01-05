using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venta
    {
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public Guid ClienteId { get; set; }

        public decimal Total { get; set; }

        public ICollection<VentaItem> VentaItems { get; set; } = new List<VentaItem>();
    }
}
