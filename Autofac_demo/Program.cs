using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Autofac;
using Autofac_demo.Setting;


namespace Autofac_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DependencyConfig.Register();
            var globalSettings = container.Resolve<GlobalSettings>();

            HostFactory.Run(x=> 
            {
                x.Service<MyTestServer>(s =>
                {
                    s.ConstructUsing(()=>container.Resolve<MyTestServer>());
                    s.WhenStarted(tc => tc.Start(globalSettings.ServiceName));
                    s.WhenStopped(tc=>tc.Stop(globalSettings.ServiceName));
                });
                x.RunAsLocalSystem();
                x.SetDescription(globalSettings.ServiceName);
                x.SetDisplayName(globalSettings.ServiceName);
                x.SetServiceName(globalSettings.ServiceName);                
                });
            Console.ReadKey();
        }
    }
}
