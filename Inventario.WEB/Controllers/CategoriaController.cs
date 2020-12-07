using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.Categoria.Filtro;
using Inventario.Core.Dto.Categoria.Input;
using Inventario.Core.Dto.Categoria.Output;
using Inventario.Core.Service;
using Inventario.WEB.Helpers;
using Inventario.WEB.Models;
using Inventario.WEB.Models.Categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Inventario.WEB.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly int _cantXPage;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            _cantXPage = 10;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(ListaCategoriaVm model)
        {
            FiltroCategoriaDto filtro = new FiltroCategoriaDto();
            filtro.Nombre = model.Nombre;
            if (model.Estado == null)
                filtro.Estado = Core.Enums.Estado.Activo;
            else
                filtro.Estado = model.Estado;
            DataEntityPager<CategoriaOutput> result = await _categoriaService.GetCategoriasAsync(filtro, _cantXPage, model.Page);
            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = model.Page,
                ItemsPerPage = _cantXPage,
                TotalItems = result.CantidadTotal
            };
            model.Categorias = result.Results;
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> DetalleCategoria(int codigo)
        {
            CategoriaOutput categoria = await _categoriaService.GetCategoriaById(codigo);
            string titulo = (codigo == 0) ? "Agregar Nueva Categoria" : "Modificar Categoria";
            categoria = categoria == null ? new CategoriaOutput() : categoria;
            CategoriaVm resultado = _mapper.Map<CategoriaVm>(categoria);
            string htmlViewForm = await this.RenderViewAsync("_FormCategoria", resultado);
            return Json(new { htmlViewParial = htmlViewForm, titulo = titulo });
        }
        [HttpPost]
        public async Task<JsonResult> AgregarEditarCategoria(CategoriaVm categoriaVm)
        {
            string mensaje = (categoriaVm.IdCategoria == 0) ? "Categoria Insertada Con exito" : "Categoria Modificada con exito";
            if (!ModelState.IsValid)
            {
                List<string> validationErrors = GetErrorListFromModelState(ModelState);
                return Json(new { success = false, validationErrors });
            }
            CategoriaInput categoriaInput = _mapper.Map<CategoriaInput>(categoriaVm);
            await _categoriaService.AgregarEditarCategiriasAsync(categoriaInput);
            string htmlViewTable = await GetParcialView();
            return Json(new { success = true, viewPartial = htmlViewTable, mensaje = mensaje });
        }
        [HttpPost]
        public async Task<JsonResult> EliminarCategoria(int codigo)
        {
            await _categoriaService.EliminarCategoriaAsync(codigo);
            string mensaje = "La categoria se elimino exitosamente.";
            bool isValid = true;
            string htmlViewTable = await GetParcialView();
            return Json(new { success = isValid, mensaje = mensaje, viewParcial = htmlViewTable });
        }
        [HttpPost]
        public async Task<JsonResult> DesactivarCategoria(int codigo, bool activo)
        {
            await _categoriaService.DesactivarActivarCategoriaAsync(codigo, activo);
            string mensaje = "";
            if (activo == true)
                mensaje = "La categoria se activo exitosamente.";
            else
                mensaje = "La categoria se desactivo exitosamente";

            string htmlViewTable = await GetParcialView();
            return Json(new { mensaje = mensaje, viewParcial = htmlViewTable });
        }
        #region
        /// <summary>
        /// Metodo que retorna la vista parcial de la tabla por defecto para ahorrar codigo
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task<string> GetParcialView()
        {
            ListaCategoriaVm model = new ListaCategoriaVm();
            //obtenemos la lista de las secciones ingresadas
            FiltroCategoriaDto filtro = new FiltroCategoriaDto();
            filtro.Estado = Core.Enums.Estado.Activo;
            DataEntityPager<CategoriaOutput> result = await _categoriaService.GetCategoriasAsync(filtro, _cantXPage, model.Page);
            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = model.Page,
                ItemsPerPage = _cantXPage,
                TotalItems = result.CantidadTotal
            };
            model.Categorias = result.Results;
            string htmlViewTable = await this.RenderViewAsync("_TablaCategoria", model);
            return htmlViewTable;
        }
        /// <summary>
        /// Metodo que extrate la lista de errores en List<string>
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        private List<string> GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToList();
        }
        #endregion
    }
}