using AutoMapper;
using Inventario.Core.Dto.Categoria.Input;
using Inventario.Core.Dto.Categoria.Output;
using Inventario.Core.Dto.Marca.Input;
using Inventario.Core.Dto.Marca.Output;
using Inventario.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //categoria
            CreateMap<CategoriaInput, Categoria>().ReverseMap();
            CreateMap<CategoriaOutput, Categoria>().ReverseMap();

            //Marca
            CreateMap<MarcaInput, Marca>().ReverseMap();
            CreateMap<MarcaOutput, Marca>().ReverseMap();
        }
    }
}
