using Autofac;
using Autofac.Configuration;
using Flight.Product.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacDemo
{
    class AutofacConfigDemo
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            IContainer container = builder.Build();

            Console.WriteLine(container.Resolve<ICacheProvider>());
            Console.ReadLine();
        }
    }
}
