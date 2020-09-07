using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.Marca.Filtro;
using Inventario.Core.Dto.Marca.Input;
using Inventario.Core.Dto.Marca.Output;
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
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;
        public MarcaService(IMarcaRepository marcaRepository, IMapper mapper)
        {

            _marcaRepository = marcaRepository;
            _mapper = mapper;

        }
        public async Task AgregarEditarMarcaAsync(MarcaInput marca)
        {
            if (marca.Codigo.GetValueOrDefault(0) > 0)
            {
                Marca marca1 = await _marcaRepository.GetMarcaById(marca.Codigo.Value, trackear: true);
                _mapper.Map<MarcaInput, Marca>(marca, marca1);
            }
            else
            {
                Marca marca1 = _mapper.Map<Marca>(marca);
                await _marcaRepository.AgregarEditarMarcaAsync(marca1);
            }
            await _marcaRepository.SaveChangesAsync();
        }

        public async Task DesactivarActivarMarcaAsync(int codigo, bool activar)
        {
            Marca marca = await _marcaRepository.GetMarcaById(codigo, trackear: true);
            marca.Activo = activar;
            await _marcaRepository.SaveChangesAsync();
        }

        public async Task EliminarMarcaAsync(int idMarca)
        {
            await _marcaRepository.EliminarMarcaAsync(idMarca);
            await _marcaRepository.SaveChangesAsync();
        }

        public async Task<MarcaOutput> GetMarcaById(int idMarca)
        {
            Marca marca = await _marcaRepository.GetMarcaById(idMarca);
            MarcaOutput marcaOutput = _mapper.Map<MarcaOutput>(marca);
            return marcaOutput;
        }

        public async Task<DataEntityPager<MarcaOutput>> GetMarcasAsync(FiltroMarcaDto filtro, int itemperpage, int page)
        {
            //verificamos los parametros del filtro para poder verificar si vienen vacios
            bool isNullNombre = string.IsNullOrEmpty(filtro.Nombre);
            Expression<Func<Marca, bool>> where = x => ((isNullNombre) || (x.NombreMarca.Contains(filtro.Nombre)))
            && ((filtro.Estado == Core.Enums.Estado.Activo && x.Activo == true)
            || (filtro.Estado == Core.Enums.Estado.Inactivo && x.Activo == false) || (filtro.Estado == Core.Enums.Estado.Todos));

            List<Marca> marcas = await _marcaRepository.GetMarcaAsync(where, itemperpage, page);
            List<MarcaOutput> result = _mapper.Map<List<MarcaOutput>>(marcas);
            int totalItems = await _marcaRepository.CountAsync(where);
            DataEntityPager<MarcaOutput> lista = new DataEntityPager<MarcaOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;

            return lista;
        }
    }
}
