using Jumper.WebServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jumper
{
    class Program
    {
        static void Main(string[] args)
        {
            JumperWebServer jumper = new JumperWebServer();
            jumper.Start("http://10.0.0.5:9900/");

            Thread.Sleep(int.MaxValue);

            jumper.Stop();
        }
    }
}
