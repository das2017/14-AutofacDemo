using Autofac;
using Flight.Product.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacDemo
{
    class AutofacDemo
    {
        static void Main1(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();

            //无参构造函数
            builder.RegisterType<RedisCacheProvider>().As<ICacheProvider>();
            //有参构造函数
            builder.RegisterType<RedisCacheProvider>().WithParameter(new NamedParameter("redisServerIP", "6.6.6.6"));

            //同一接口注册多个实现，通过不同的Name加以区分
            builder.RegisterType<LocalCacheProvider>().Named<ICacheProvider>("Local");
            builder.RegisterType<RedisCacheProvider>().Named<ICacheProvider>("Redis");

            //同一接口注册多个实现，通过不同的Key加以区分
            builder.RegisterType<LocalCacheProvider>().Keyed<ICacheProvider>(CacheType.Local);
            builder.RegisterType<RedisCacheProvider>().Keyed<ICacheProvider>(CacheType.Redis);

            //属性注入
            //builder.Register<RedisCacheProvider>(a => new RedisCacheProvider() { RedisServerIP = "127.0.0.1" });

            IContainer container = builder.Build();

            Console.WriteLine(container.Resolve<ICacheProvider>());            

            Console.WriteLine(container.ResolveNamed<ICacheProvider>("Local"));
            Console.WriteLine(container.ResolveNamed<ICacheProvider>("Redis"));

            Console.WriteLine(container.ResolveKeyed<ICacheProvider>(CacheType.Local));
            Console.WriteLine(container.ResolveKeyed<ICacheProvider>(CacheType.Redis));

            Console.WriteLine(container.Resolve<RedisCacheProvider>().RedisServerIP);
            Console.WriteLine(container.Resolve<RedisCacheProvider>(new NamedParameter("redisServerIP", "8.8.8.8")).RedisServerIP);            
            //Console.WriteLine(container.Resolve<LocalCacheProvider>().ServerAddress);

            Console.ReadLine();
        }
    }

    public enum CacheType
    {
        Local,
        Redis
    }
}
