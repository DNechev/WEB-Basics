using SIS.MvcFramework;
using System;
using System.Globalization;
using System.Threading;

namespace Panda.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            WebHost.Start(new StartUp());
        }
    }
}
