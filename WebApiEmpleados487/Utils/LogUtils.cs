using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEmpleados487.Utils
{
   public class LogUtils
    {
       public static void EscribirLog(String contenido)
       {
           using (var destino=File.AppendText(@"c:\log\log-webapi.txt"))
           {
               destino.WriteLine(contenido);

           }

       }
    }
}
