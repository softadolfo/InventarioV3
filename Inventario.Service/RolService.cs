using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.Rol.Filtro;
using Inventario.Core.Dto.Rol.Input;
using Inventario.Core.Dto.Rol.Output;
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
    public class RolService : IRolService
    {
        public readonly IRolRepository _rolRepository;
        public readonly IMapper _mapper;

        public RolService(IRolRepository rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }
        public async Task AgregarEditarRolAsync(RolInput rol)
        {
            if (rol.Codigo.GetValueOrDefault(0) > 0)
            {
                Rol rol1 = await _rolRepository.GetRolById(rol.Codigo.Value, trackear: true);
                _mapper.Map<RolInput, Rol>(rol, rol1);
            }
            else
            {
                Rol rol1 = _mapper.Map<Rol>(rol);
                await _rolRepository.AgregarEditarRolAsync(rol1);
            }
            await _rolRepository.SaveChangesAsync();
        }

        public async Task EliminarRolAsync(int idRol)
        {
            await _rolRepository.EliminarRolAsync(idRol);
            await _rolRepository.SaveChangesAsync();
        }

        public async Task<DataEntityPager<RolOutput>> GetRolAsync(FiltroRolDto filtro, int itemperpage, int page)
        {
            //verificamos los parametros del filtro para poder verificar si vienen vacios
            bool isNullNombre = string.IsNullOrEmpty(filtro.Rol);
            Expression<Func<Rol, bool>> where = x => ((isNullNombre) || (x.Descripcion.Contains(filtro.Rol)));

            List<Rol> rols = await _rolRepository.GetRolAsync(where, itemperpage, page);
            List<RolOutput> result = _mapper.Map<List<RolOutput>>(rols);
            int totalItems = await _rolRepository.CountAsync(where);
            DataEntityPager<RolOutput> lista = new DataEntityPager<RolOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;

            return lista;
        }

        public async Task<RolOutput> GetRolById(int idRol)
        {
            Rol rol = await _rolRepository.GetRolById(idRol);
            RolOutput rolOutput = _mapper.Map<RolOutput>(rol);
            return rolOutput;
        }
    }
}
