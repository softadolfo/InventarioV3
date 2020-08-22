using Inventario.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.WEB.ViewComponents
{
    public class PaginacionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            PagingVm model = new PagingVm()
            {
                PaginaActiva = pagingInfo.CurrentPage,
                Botones = new List<BotonPaginacionVm>()
            };
            int totalP = 10;
            int ipage = 1;

            //Pagina anterior
            if (pagingInfo.CurrentPage > 1)
            {
                model.UrlPaginaAnterior = pageUrl(pagingInfo.CurrentPage - 1);
            }

            if (totalP > pagingInfo.TotalPages)
                totalP = pagingInfo.TotalPages;

            if (pagingInfo.CurrentPage > 6)
            {
                totalP = pagingInfo.CurrentPage + 4;
                ipage = pagingInfo.CurrentPage - 5;

                if (totalP > pagingInfo.TotalPages)
                {
                    totalP = pagingInfo.TotalPages;
                    ipage = pagingInfo.TotalPages - 9;
                    if (ipage < 1)
                    {
                        ipage = 1;
                    }

                }
            }

            if (totalP != 1)
            {
                for (int i = ipage; i <= totalP; i++)
                {
                    model.Botones.Add(new BotonPaginacionVm()
                    {
                        Pagina = i,
                        UrlBoton = pageUrl(i)
                    });
                }
            }


            //Pagina siguiente
            if (pagingInfo.CurrentPage < pagingInfo.TotalPages)
            {
                model.UrlPaginaSiguiente = pageUrl(pagingInfo.CurrentPage + 1);
            }

            return View(model);
        }
    }
}
