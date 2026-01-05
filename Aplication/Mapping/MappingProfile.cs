using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTOs>().ReverseMap();
            CreateMap<Producto, ProductoDTOs>().ReverseMap();
            CreateMap<Venta, VentaDTOs>().ReverseMap();
            CreateMap<VentaItem, VentaItemDTOs>().ReverseMap();
        }
    }
}
