using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.Producto.Filtro;
using Inventario.Core.Dto.Producto.Input;
using Inventario.Core.Dto.Producto.Output;
using Inventario.Core.Model;
using Inventario.Core.Repository;
using Inventario.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
        public async Task AgregarEditarProductoAsync(ProductoInput producto)
        {
            if (producto.Codigo.GetValueOrDefault(0) > 0)
            {
                Producto producto1 = await _productoRepository.GetProducotById(producto.Codigo.Value, trackear: true);
                _mapper.Map<ProductoInput, Producto>(producto, producto1);
            }
            else
            {
                Producto producto1 = _mapper.Map<Producto>(producto);
                await _productoRepository.AgregarEditarProductoAsync(producto1);
            }
            await _productoRepository.SaveChangesAsync();
        }

        public async Task EliminarProductoAsync(int idProducto)
        {
            await _productoRepository.EliminarProductoAsync(idProducto);
            await _productoRepository.SaveChangesAsync();
        }

        public async Task<ProductoOutput> GetProductoById(int idProducto)
        {
            
            
            Producto producto = await _productoRepository.GetProducotById(idProducto);
            ProductoOutput productoResult = _mapper.Map<ProductoOutput>(producto);
            return productoResult;
        }

        public async Task<DataEntityPager<ProductoOutput>> GetProductosAsync(FiltroProductoDto filtro, int itemperpage, int page)
        {
            bool isNombreValido = string.IsNullOrEmpty(filtro.Nombre);
            bool marcaSelected = string.IsNullOrEmpty(filtro.Marca);
            bool categoriaSelected = string.IsNullOrEmpty(filtro.Categoria);
            Expression<Func<Producto, bool>> where = x => ((isNombreValido) || (x.NombreProducto.Contains(filtro.Nombre))
            && ((marcaSelected) || (x.IdMarca == int.Parse(filtro.Marca))) && ((categoriaSelected) || (x.IdCategoria == int.Parse(filtro.Categoria))) 
            && ((filtro.TipoProducto == Core.Dto.Producto.TipoProductoFiltro.Ropa && x.TipoProducto == Core.Enums.TipoProducto.Ropa) 
            || (filtro.TipoProducto == Core.Dto.Producto.TipoProductoFiltro.Zapatos && x.TipoProducto == Core.Enums.TipoProducto.Zapatos))
            || (filtro.TipoProducto == Core.Dto.Producto.TipoProductoFiltro.Todos) && ((filtro.Estado == Core.Enums.Estado.Activo && x.Activo == true)
            || (filtro.Estado == Core.Enums.Estado.Inactivo && x.Activo == false) || (filtro.Estado == Core.Enums.Estado.Todos)));

            List<Producto> productos = await _productoRepository.GetProductosAsync(where, itemperpage, page);
            List<ProductoOutput> result = _mapper.Map<List<ProductoOutput>>(productos);
            int totalItems = await _productoRepository.CountAsync(where);
            DataEntityPager<ProductoOutput> lista = new DataEntityPager<ProductoOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;
            return lista;
        }

        public async Task<List<ProductoOutput>> GetProductosMarcaAsync(int idProducto)
        {
            List<Producto> productos = await _productoRepository.GetProductoMarcaAsync(idProducto);
            List<ProductoOutput> result = _mapper.Map<List<ProductoOutput>>(productos);
            return result;
        }
    }
}
