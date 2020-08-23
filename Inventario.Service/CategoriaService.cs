using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.Categoria.Filtro;
using Inventario.Core.Dto.Categoria.Input;
using Inventario.Core.Dto.Categoria.Output;
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
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper) {

            _categoriaRepository = categoriaRepository;
            _mapper = mapper;

        }
        public async Task AgregarEditarCategiriasAsync(CategoriaInput categoriaInput)
        {
            if (categoriaInput.IdCategoria.GetValueOrDefault(0) > 0)
            {
                Categoria categoria1 = await _categoriaRepository.GetCategoriaById(categoriaInput.IdCategoria.Value, trackear: true);
                _mapper.Map<CategoriaInput, Categoria>(categoriaInput, categoria1);
            }
            else
            {
                Categoria categoria = _mapper.Map<Categoria>(categoriaInput);
                await _categoriaRepository.AgregarEditarCategiriasAsync(categoria);
            }
            await _categoriaRepository.SaveChangesAsync();
        }

        public async Task EliminarCategoriaAsync(int idCategoria)
        {
            await _categoriaRepository.EliminarCategoriaAsync(idCategoria);
            await _categoriaRepository.SaveChangesAsync();
        }

        public async Task<CategoriaOutput> GetCategoriaById(int idCategoria)
        {
            Categoria categoria = await _categoriaRepository.GetCategoriaById(idCategoria);
            CategoriaOutput categoriaOutput = _mapper.Map<CategoriaOutput>(categoria);
            return categoriaOutput;
        }

        public async Task<DataEntityPager<CategoriaOutput>> GetCategoriasAsync(FiltroCategoriaDto filtro, int itemperpage, int page)
        {
            //verificamos los parametros del filtro para poder verificar si vienen vacios
            bool isNullNombre = string.IsNullOrEmpty(filtro.Nombre);
            Expression<Func<Categoria, bool>> where = x => ((isNullNombre) || (x.NombreCategoria.Contains(filtro.Nombre)));

            List<Categoria> categorias = await _categoriaRepository.GetCategoriasAsync(where, itemperpage, page);
            List<CategoriaOutput> result = _mapper.Map<List<CategoriaOutput>>(categorias);
            int totalItems = await _categoriaRepository.CountAsync(where);
            DataEntityPager<CategoriaOutput> lista = new DataEntityPager<CategoriaOutput>();
            lista.CantidadPorPagina = itemperpage;
            lista.CantidadTotal = totalItems;
            lista.PaginaActual = page;
            lista.Results = result;

            return lista;
        }
    }
}
