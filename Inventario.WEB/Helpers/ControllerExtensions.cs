using Inventario.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Inventario.WEB.Helpers
{
    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewComponentAsync(this Controller controller, string nombreComponent, object parametros = null)
        {
            var servicesProvider = controller.HttpContext.RequestServices;
            var helper = new DefaultViewComponentHelper(
            servicesProvider.GetRequiredService<IViewComponentDescriptorCollectionProvider>(),
            HtmlEncoder.Default,
            servicesProvider.GetRequiredService<IViewComponentSelector>(),
            servicesProvider.GetRequiredService<IViewComponentInvokerFactory>(),
            servicesProvider.GetRequiredService<IViewBufferScope>());

            using (var writer = new StringWriter())
            {

                var context = new ViewContext(controller.ControllerContext, NullView.Instance, controller.ViewData, controller.TempData, writer, new HtmlHelperOptions());
                helper.Contextualize(context);
                var result = await helper.InvokeAsync(nombreComponent, parametros);
                result.WriteTo(writer, HtmlEncoder.Default);
                await writer.FlushAsync();
                return writer.ToString();
            }
        }

        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false) where TModel : class
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }

            controller.ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);

                if (viewResult.Success == false)
                {
                    return $"La vista con el nombre {viewName} no fué encontrada";
                }

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
