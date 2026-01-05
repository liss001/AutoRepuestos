using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class ProductoDTOs
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
