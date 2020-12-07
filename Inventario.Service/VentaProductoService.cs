using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.VentaProducto.Input;
using Inventario.Core.Dto.VentaProducto.Output;
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
    public class VentaProductoService : IVentaProductoService
    {
        private readonly IVentaProductoRepository _ventaProductoRepository;
        private readonly IMapper _mapper;
        public VentaProductoService(IVentaProductoRepository ventaProductoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ventaProductoRepository = ventaProductoRepository;
        }
        public async Task AgregarEditarVentaProductoAsync(VentaProductoInput ventaProducto)
        {
            if (ventaProducto.Codigo.GetValueOrDefault(0) > 0)
            {
                VentaProducto ventaProducto1 = await _ventaProductoRepository.GetCategoriaById(ventaProducto.Codigo.Value, trackear: true);
                _mapper.Map<VentaProductoInput, VentaProducto>(ventaProducto, ventaProducto1);
            }
            else
            {
                VentaProducto registroVenta1 = _mapper.Map<VentaProducto>(ventaProducto);
                await _ventaProductoRepository.AgregarEditarCategiriasAsync(registroVenta1);
            }
            await _ventaProductoRepository.SaveChangesAsync();
        }

        public async Task EliminarVentaProductoAsync(int idVenta)
        {
            await _ventaProductoRepository.EliminarCategoriaAsync(idVenta);
            await _ventaProductoRepository.SaveChangesAsync();
        }

        public async Task<DataEntityPager<VentaProductoOutput>> GetVentaProductoAsync(int itemperpage, int page)
        {
            Expression<Func<VentaProducto, bool>> where = x => (true);

            List<VentaProducto> ventaProductos = await _ventaProductoRepository.GetCategoriasAsync(where, itemperpage, page);
            List<VentaProductoOutput> result = _mapper.Map<List<VentaProductoOutput>>(ventaProductos);
            int totalItems = await _ventaProductoRepository.CountAsync(where);
            DataEntityPager<VentaProductoOutput> lista = new DataEntityPager<VentaProductoOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;
            return lista;
        }

        public async Task<VentaProductoOutput> GetVentaProductoById(int idVenta)
        {
            VentaProducto ventaProducto = await _ventaProductoRepository.GetCategoriaById(idVenta);
            VentaProductoOutput ventaProductoOutput = _mapper.Map<VentaProductoOutput>(ventaProducto);
            return ventaProductoOutput;
        }
    }
}
