using AutoMapper;
using Inventario.Core.Dto.Categoria.Input;
using Inventario.Core.Dto.Categoria.Output;
using Inventario.Core.Dto.Marca.Input;
using Inventario.Core.Dto.Marca.Output;
using Inventario.Core.Dto.Producto.Input;
using Inventario.Core.Dto.Producto.Output;
using Inventario.Core.Dto.RegistroEntradaProducto.Input;
using Inventario.Core.Dto.RegistroEntradaProducto.Output;
using Inventario.Core.Dto.RegistroVenta.Input;
using Inventario.Core.Dto.RegistroVenta.Output;
using Inventario.Core.Dto.Rol.Input;
using Inventario.Core.Dto.Rol.Output;
using Inventario.Core.Dto.TipoUsuario.Input;
using Inventario.Core.Dto.TipoUsuario.Output;
using Inventario.Core.Dto.UserRol.Input;
using Inventario.Core.Dto.UserRol.Output;
using Inventario.Core.Dto.VentaProducto.Input;
using Inventario.Core.Dto.VentaProducto.Output;
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

            //producto 
            CreateMap<ProductoOutput, Producto>().ReverseMap();
            CreateMap<ProductoInput, Producto>().ReverseMap();

            //registro entrada producto
            CreateMap<RegistroEntradaProducto, RegistroEntradaInput>().ReverseMap();
            CreateMap<RegistroEntradaOutput, RegistroEntradaProducto>().ReverseMap();

            //registro venta 
            CreateMap<RegistroVenta, RegistroVentaInput>().ReverseMap();
            CreateMap<RegistroVenta, RegistroVentaOutput>().ReverseMap();

            //Rol
            CreateMap<RolInput, Rol>().ReverseMap();
            CreateMap<RolOutput, Rol>().ReverseMap();

            //tipo usuario 
            CreateMap<TipoUsuario, TipoUsuarioInput>().ReverseMap();
            CreateMap<TipoUsuario, TipoUsuarioOutput>().ReverseMap();

            //Usuario rol
            CreateMap<UserRol, UserRolInput>().ReverseMap();
            CreateMap<UserRol, UserRolOutput>().ReverseMap();

            //venta producto
            CreateMap<VentaProducto, VentaProductoInput>().ReverseMap();
            CreateMap<VentaProducto, VentaProductoOutput>().ReverseMap();
        }
    }
}
