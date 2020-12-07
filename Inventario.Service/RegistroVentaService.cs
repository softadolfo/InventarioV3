using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.RegistroVenta.Filtro;
using Inventario.Core.Dto.RegistroVenta.Input;
using Inventario.Core.Dto.RegistroVenta.Output;
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
    public class RegistroVentaService : IRegistroVentaService
    {
        private readonly IRegistroVentaRepository _registroVentaRepository;
        private readonly IMapper _mapper;
        public RegistroVentaService(IRegistroVentaRepository registroVentaRepository, IMapper mapper)
        {
            _registroVentaRepository = registroVentaRepository;
            _mapper = mapper;
        }

        public async Task AgregarEditarRegistroVentaAsync(RegistroVentaInput registroVenta)
        {
            if (registroVenta.Codigo.GetValueOrDefault(0) > 0)
            {
                RegistroVenta registroVenta1 = await _registroVentaRepository.GetRegistroVentaById(registroVenta.Codigo.Value, trackear: true);
                _mapper.Map<RegistroVentaInput, RegistroVenta>(registroVenta, registroVenta1);
            }
            else
            {
                RegistroVenta registroVenta1 = _mapper.Map<RegistroVenta>(registroVenta);
                await _registroVentaRepository.AgregarEditarRegistroVentaAsync(registroVenta1);
            }
            await _registroVentaRepository.SaveChangesAsync();
        }

        public async Task EliminarRegistroVentaAsync(int idVenta)
        {
            await _registroVentaRepository.EliminarRegistroVentaAsync(idVenta);
            await _registroVentaRepository.SaveChangesAsync();
        }

        public async Task<DataEntityPager<RegistroVentaOutput>> GetRegistroVentaAsync(FiltroRegistroVentaDto filtro, int itemperpage, int page)
        {
            bool isNombre = string.IsNullOrEmpty(filtro.NombreUsuario);
            Expression<Func<RegistroVenta, bool>> where = x => ((isNombre) || (x.IdUsuario.Contains(filtro.NombreUsuario))
            && (x.FechaVenta == filtro.Fecha));

            List<RegistroVenta> registroVentas = await _registroVentaRepository.GetRegistroVentaAsync(where, itemperpage, page);
            List<RegistroVentaOutput> result = _mapper.Map<List<RegistroVentaOutput>>(registroVentas);
            int totalItems = await _registroVentaRepository.CountAsync(where);
            DataEntityPager<RegistroVentaOutput> lista = new DataEntityPager<RegistroVentaOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;
            return lista;
        }

        public async Task<RegistroVentaOutput> GetRegistroVentaById(int idVenta)
        {
            RegistroVenta registroVenta = await _registroVentaRepository.GetRegistroVentaById(idVenta);
            RegistroVentaOutput registroVentaOutput = _mapper.Map<RegistroVentaOutput>(registroVenta);
            return registroVentaOutput;
        }
    }
}
