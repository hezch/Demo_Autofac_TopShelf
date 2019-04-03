using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac_demo
{
    public class MyTestServer
    {
        public void Start(string serviceName)
        {
            Console.WriteLine("服务启动");
        }
        public void Stop(string serviceName)
        {
            Console.WriteLine("服务停止");
        }
    }
}
