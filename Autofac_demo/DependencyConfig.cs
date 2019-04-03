using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac_demo.Setting;

namespace Autofac_demo
{
    static class DependencyConfig
    {
        /// <summary>
        /// 为一组组件创建、连接依赖项并管理生存期。autofac.icontainer的大多数实例都是由autofac.containerBuilder创建的。
        /// </summary>
        public static IContainer Container { get; set; }
        public static IContainer Register()
        {
            if (Container==null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<GlobalSettings>().InstancePerLifetimeScope();

                //注册要通过反射创建的组件
                builder.RegisterType<MyTestServer>().InstancePerLifetimeScope();

                Container = builder.Build();
            }
            return Container;
        }

    }
}
