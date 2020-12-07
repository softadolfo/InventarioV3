using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.RegistroEntradaProducto.Filtro;
using Inventario.Core.Dto.RegistroEntradaProducto.Input;
using Inventario.Core.Dto.RegistroEntradaProducto.Output;
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
    public class RegistroEntradaProductoService : IRegistroEntradaProductoService
    {
        private readonly IRegistroEntradaProductoRepository _registroEntradaProductoRepository;
        private readonly IMapper _mapper;
        public RegistroEntradaProductoService(IRegistroEntradaProductoRepository registroEntradaProductoRepository, IMapper mapper)
        {
            _registroEntradaProductoRepository = registroEntradaProductoRepository;
            _mapper = mapper;
        }
        public async Task AgregarEditarRegistroEntradaProductoAsync(RegistroEntradaInput registroEntrada)
        {
            if (registroEntrada.Codigo.GetValueOrDefault(0) > 0)
            {
                RegistroEntradaProducto registroEntrada1 = await _registroEntradaProductoRepository.GetRegistroEntradaProductoById(registroEntrada.Codigo.Value, trackear: true);
                _mapper.Map<RegistroEntradaInput, RegistroEntradaProducto>(registroEntrada, registroEntrada1);
            }
            else
            {
                RegistroEntradaProducto registro = _mapper.Map<RegistroEntradaProducto>(registroEntrada);
                await _registroEntradaProductoRepository.AgregarEditarRegistroEntradaProductoAsync(registro);
            }
            await _registroEntradaProductoRepository.SaveChangesAsync();
        }

        public async Task EliminarRegistroEntradaProductoAsync(int idRegistro)
        {
            await _registroEntradaProductoRepository.EliminarRegistroEntradaProductoAsync(idRegistro);
            await _registroEntradaProductoRepository.SaveChangesAsync();
        }

        public async Task<DataEntityPager<RegistroEntradaOutput>> GetRegistroEntradaProductosAsync(FiltroEntradaProdDto filtro, int itemperpage, int page)
        {
            bool isNombreNull = string.IsNullOrEmpty(filtro.NombreProducto);
            Expression<Func<RegistroEntradaProducto, bool>> where = x => ((isNombreNull) || (x.Producto.NombreProducto.Contains(filtro.NombreProducto)) 
            && (x.FechaIngreso == filtro.Fecha));

            List<RegistroEntradaProducto> registroEntradaProductos = await _registroEntradaProductoRepository.GetRegistroEntradaProductoAsync(where, itemperpage, page);
            List<RegistroEntradaOutput> result = _mapper.Map<List<RegistroEntradaOutput>>(registroEntradaProductos);
            int totalItems = await _registroEntradaProductoRepository.CountAsync(where);
            DataEntityPager<RegistroEntradaOutput> lista = new DataEntityPager<RegistroEntradaOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;
            return lista;
        }

        public async Task<RegistroEntradaOutput> GetRegistroEntradaProductoById(int idRegistro)
        {
            RegistroEntradaProducto registroEntradaProducto = await _registroEntradaProductoRepository.GetRegistroEntradaProductoById(idRegistro);
            RegistroEntradaOutput registroEntradaOutput = _mapper.Map<RegistroEntradaOutput>(registroEntradaProducto);
            return registroEntradaOutput;
        }
    }
}
