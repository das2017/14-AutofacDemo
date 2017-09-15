using Flight.Product.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacDemo
{
    class UtilityDemo
    {
        private static ILogProvider logger = UtilityService.GetLogger("FileLogger".GetType());

        static void Main1(string[] args)
        {
            ICacheProvider localCache = UtilityService.GetLocalCache();
            localCache.SetCache<string>("LocalCacheKey", "Value from LocalCache", DateTime.Now.AddMinutes(2));
            Console.WriteLine(localCache.GetCache<string>("LocalCacheKey"));

            ICacheProvider redisCache = UtilityService.GetRedisCache();
            redisCache.SetCache<string>("RedisCacheKey", "Value from Redis", DateTime.Now.AddMinutes(2));
            Console.WriteLine(redisCache.GetCache<string>("RedisCacheKey"));

            logger.Info("Autofac Demo");
            Console.ReadLine();
        }
    }
}
