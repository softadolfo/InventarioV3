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

        public async Task<DataEntityPager<ProductoInput>> GetProductosAsync(FiltroProductoDto filtro, int itemperpage, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductoOutput>> GetProductosMarcaAsync(int idProducto)
        {
            List<Producto> productos = await _productoRepository.GetProductoMarcaAsync(idProducto);
            List<ProductoOutput> result = _mapper.Map<List<ProductoOutput>>(productos);
            return result;
        }
    }
}
