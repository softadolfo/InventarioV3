using AutoMapper;
using Inventario.Core.Dto.Marca.Input;
using Inventario.Core.Dto.Marca.Output;
using Inventario.WEB.Models.Marca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.WEB.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MarcaOutput, MarcaVm>().ReverseMap();
            CreateMap<MarcaInput, MarcaVm>().ReverseMap();
        }
    }
}
