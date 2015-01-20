using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiEmpleados487.Utils;

namespace WebApiEmpleados487.Extensiones
{
   public class LogHandler:DelegatingHandler
    {
       protected override Task<HttpResponseMessage> 
           SendAsync(HttpRequestMessage request, 
           CancellationToken cancellationToken)
       {
           var mensaje = String.Format("{0:G} Request->{1}", DateTime.Now, request);
           LogUtils.EscribirLog(mensaje);
           
           return base.SendAsync(request, cancellationToken);
       }

    }
}
