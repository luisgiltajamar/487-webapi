using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiEmpleados487.Utils;

namespace WebApiEmpleados487.Extensiones
{
   public class FiltroLog:Attribute,IActionFilter
    {
       public bool AllowMultiple {
           get { return true; }
       }
       public async Task<HttpResponseMessage> ExecuteActionFilterAsync
           (HttpActionContext actionContext, 
           CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
       {
           LogUtils.EscribirLog("Empiezo con el filtro");
           foreach (var actionArgument in actionContext.ActionArguments)
           {
               LogUtils.EscribirLog(String.Format("{0}:{1}",actionArgument.Key,
                   actionArgument.Value));
           }
           var resp = await continuation();

           LogUtils.EscribirLog("Termino con el filtro");

           return resp;
       }
    }
}
