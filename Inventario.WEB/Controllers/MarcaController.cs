using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventario.Core.Dto;
using Inventario.Core.Dto.Marca.Filtro;
using Inventario.Core.Dto.Marca.Output;
using Inventario.Core.Service;
using Inventario.WEB.Models;
using Inventario.WEB.Models.Marca;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.WEB.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMarcaService _marcaService;
        private readonly int _cantXPage;
        public MarcaController(IMapper mapper, IMarcaService marcaService)
        {
            _marcaService = marcaService;
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
    }
}