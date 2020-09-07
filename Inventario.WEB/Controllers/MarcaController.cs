using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.Marca.Filtro;
using Inventario.Core.Dto.Marca.Input;
using Inventario.Core.Dto.Marca.Output;
using Inventario.Core.Dto.Producto.Output;
using Inventario.Core.Service;
using Inventario.WEB.Helpers;
using Inventario.WEB.Models;
using Inventario.WEB.Models.Marca;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Inventario.WEB.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMarcaService _marcaService;
        private readonly IProductoService _productoService;
        private readonly int _cantXPage;
        public MarcaController(IMapper mapper, IMarcaService marcaService, IProductoService productoService)
        {
            _marcaService = marcaService;
            _productoService = productoService;
            _mapper = mapper;
            _cantXPage = 10;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ListaMarcaVm model)
        {
            FiltroMarcaDto filtro = new FiltroMarcaDto();
            filtro.Nombre = model.Nombre;
            if (model.Estado == null)
                filtro.Estado = Core.Enums.Estado.Activo;
            else
                filtro.Estado = model.Estado;
            DataEntityPager<MarcaOutput> result = await _marcaService.GetMarcasAsync(filtro, _cantXPage, model.Page);
            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = model.Page,
                ItemsPerPage = _cantXPage,
                TotalItems = result.CantidadTotal
            };
            model.Marcas = result.Results;
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> DetalleMarca(int codigo)
        {
            MarcaOutput marca = await _marcaService.GetMarcaById(codigo);
            string titulo = (codigo == 0) ? "Agregar Nueva Marca" : "Modificar Marca";
            marca = marca == null ? new MarcaOutput() : marca;
            MarcaVm resultado = _mapper.Map<MarcaVm>(marca);
            string htmlViewForm = await this.RenderViewAsync("_FormMarca", resultado);
            return Json(new { htmlViewParial = htmlViewForm, titulo = titulo });
        }

        [HttpPost]
        public async Task<JsonResult> AgregarEditarMarca(MarcaVm marcaVm)
        {
            string mensaje = (marcaVm.Codigo == 0) ? "Seccion Insertada Con exito" : "Seccion Modificada con exito";
            if (!ModelState.IsValid)
            {
                List<string> validationErrors = GetErrorListFromModelState(ModelState);
                return Json(new { success = false, validationErrors });
            }
            MarcaInput marcaInput = _mapper.Map<MarcaInput>(marcaVm);
            await _marcaService.AgregarEditarMarcaAsync(marcaInput);
            string htmlViewTable = await GetParcialView();
            return Json(new { success = true, viewPartial = htmlViewTable, mensaje = mensaje });

        }
        [HttpPost]
        public async Task<JsonResult> EliminarMarca(int codigo)
        {
            await _marcaService.EliminarMarcaAsync(codigo);
            string mensaje = "La marca se elimino exitosamente.";
            bool isValid = true;
            string htmlViewTable = await GetParcialView();
            return Json(new { success = isValid, mensaje = mensaje, viewParcial = htmlViewTable });
        }

        [HttpPost]
        public async Task<JsonResult> DesactivarMarca(int codigo, bool activo)
        {
            await _marcaService.DesactivarActivarMarcaAsync(codigo, activo);
            string mensaje = "";
            if (activo == true)
                mensaje = "La seccion se activo exitosamente.";
            else
                mensaje = "La seccion se desactivo exitosamente";

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
            ListaMarcaVm model = new ListaMarcaVm();
            //obtenemos la lista de las secciones ingresadas
            FiltroMarcaDto filtro = new FiltroMarcaDto();
            filtro.Estado = Core.Enums.Estado.Activo;
            DataEntityPager<MarcaOutput> result = await _marcaService.GetMarcasAsync(filtro, _cantXPage, model.Page);
            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = model.Page,
                ItemsPerPage = _cantXPage,
                TotalItems = result.CantidadTotal
            };
            model.Marcas = result.Results;
            string htmlViewTable = await this.RenderViewAsync("_TablaMarca", model);
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