using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.TipoUsuario.Filtro;
using Inventario.Core.Dto.TipoUsuario.Input;
using Inventario.Core.Dto.TipoUsuario.Output;
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
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;
        private readonly IMapper _mapper;
        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository, IMapper mapper)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
            _mapper = mapper;
        }
        public async Task AgregarEditarTipoUsuarioAsync(TipoUsuarioInput tipoUsuario)
        {
            if (tipoUsuario.Codigo.GetValueOrDefault(0) > 0)
            {
                TipoUsuario tipoUsuario1 = await _tipoUsuarioRepository.GetTipoUsuarioById(tipoUsuario.Codigo.Value, trackear: true);
                _mapper.Map<TipoUsuarioInput, TipoUsuario>(tipoUsuario, tipoUsuario1);
            }
            else
            {
                TipoUsuario tipoUsuario1 = _mapper.Map<TipoUsuario>(tipoUsuario);
                await _tipoUsuarioRepository.AgregarEditarTipoUsuariosAsync(tipoUsuario1);
            }
            await _tipoUsuarioRepository.SaveChangesAsync();
        }

        public async Task EliminarTipoUsuarioAsync(int iTipoUsuario)
        {
            await _tipoUsuarioRepository.EliminarTipoUsuarioAsync(iTipoUsuario);
            await _tipoUsuarioRepository.SaveChangesAsync();
        }

        public async Task<DataEntityPager<TipoUsuarioOutput>> GetATipoUsuariosync(FiltroTipoUsuarioDto filtro, int itemperpage, int page)
        {
            //verificamos los parametros del filtro para poder verificar si vienen vacios
            bool isNullNombre = string.IsNullOrEmpty(filtro.Nombre);
            Expression<Func<TipoUsuario, bool>> where = x => ((isNullNombre) || (x.NombreTipoUsuario.Contains(filtro.Nombre)));

            List<TipoUsuario> tipoUsuarios = await _tipoUsuarioRepository.GetTipoUsuarioAsync(where, itemperpage, page);
            List<TipoUsuarioOutput> result = _mapper.Map<List<TipoUsuarioOutput>>(tipoUsuarios);
            int totalItems = await _tipoUsuarioRepository.CountAsync(where);
            DataEntityPager<TipoUsuarioOutput> lista = new DataEntityPager<TipoUsuarioOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;
            return lista;
        }

        public async Task<TipoUsuarioOutput> GetTipoUsuarioById(int idUsuario)
        {
            TipoUsuario tipoUsuario = await _tipoUsuarioRepository.GetTipoUsuarioById(idUsuario);
            TipoUsuarioOutput tipoUsuarioOutput = _mapper.Map<TipoUsuarioOutput>(tipoUsuario);
            return tipoUsuarioOutput;
        }
    }
}
