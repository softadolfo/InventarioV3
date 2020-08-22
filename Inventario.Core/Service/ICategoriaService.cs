using Inventario.Core.Dto.Categoria.Output;
using Inventario.Core.Dto.Categoria.Input;
using Inventario.Core.Dto.Categoria.Filtro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inventario.Core.Dto;

namespace Inventario.Core.Service
{
    public interface ICategoriaService
    {
        /// <summary>
        /// Guarda o edita las categorias insertadas
        /// </summary>
        /// <param name="categoria"
        Task AgregarEditarCategiriasAsync(CategoriaInput categoria);
        /// <summary>
        /// Regresa una lista de categorias paginada
        /// </summary>
        /// <param name="itemperpage"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        Task<DataEntityPager<CategoriaOutput>> GetCategoriasAsync(FiltroCategoriaDto filtro, int itemperpage, int page);
        /// <summary>
        /// Elimina las categorias
        /// </summary>
        Task EliminarCategoriaAsync(int idCategoria);
        /// <summary>
        /// Extrae una categoria por id
        /// </summary>
        Task<CategoriaOutput> GetCategoriaById(int idCategoria);
    }
}
