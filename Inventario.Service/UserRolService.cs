using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.UserRol.Input;
using Inventario.Core.Dto.UserRol.Output;
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
    public class UserRolService : IUserRolService
    {
        private readonly IMapper _mapper;
        private readonly IUserRolRepository _userRolRepository;

        public UserRolService(IUserRolRepository userRolRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRolRepository = userRolRepository;
        }
        public async Task AgregarEditarUserRolAsync(UserRolInput rol)
        {
            if (rol.IdRol > 0)
            {
                UserRol userRol = await _userRolRepository.GetRolById(rol.IdRol, trackear: true);
                _mapper.Map<UserRolInput, UserRol>(rol, userRol);
            }
            else
            {
                UserRol userRol = _mapper.Map<UserRol>(rol);
                await _userRolRepository.AgregarEditarRolAsync(userRol);
            }
            await _userRolRepository.SaveChangesAsync();
        }

        public async Task EliminarRolAsync(int idRol)
        {
            await _userRolRepository.EliminarRolAsync(idRol);
            await _userRolRepository.SaveChangesAsync();
        }

        public async Task<DataEntityPager<UserRolOutput>> GetUserRolAsync(int itemperpage, int page)
        {
            Expression<Func<UserRol, bool>> where = x => (true);

            List<UserRol> userRols = await _userRolRepository.GetRolAsync(where, itemperpage, page);
            List<UserRolOutput> result = _mapper.Map<List<UserRolOutput>>(userRols);
            int totalItems = await _userRolRepository.CountAsync(where);
            DataEntityPager<UserRolOutput> lista = new DataEntityPager<UserRolOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;
            return lista;
        }
        public async Task<UserRolOutput> GetUserRolById(int idRol)
        {
            UserRol userRol = await _userRolRepository.GetRolById(idRol);
            UserRolOutput userRolOutput = _mapper.Map<UserRolOutput>(userRol);
            return userRolOutput;
        }
    }
}
