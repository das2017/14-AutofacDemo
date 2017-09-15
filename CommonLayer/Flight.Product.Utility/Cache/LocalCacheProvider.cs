using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace Flight.Product.Utility
{
    /// <summary>
    /// 本地缓存
    /// </summary>
    public class LocalCacheProvider : ICacheProvider
    {
        /// <summary>
        /// 默认缓存过期时间，单位分钟，默认10分钟
        /// </summary>
        public const int DEFAULT_EXPIRE_TIME = 10;
        private System.Runtime.Caching.MemoryCache mc = MemoryCache.Default;
        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <returns></returns>
        public T GetCache<T>(string key)
        {
            return (T)mc.Get(key);
        }

        /// <summary>
        /// 新增缓存项，默认10分钟过期
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void SetCache<T>(string key, T value)
        {
            SetCache<T>(key, value, DateTime.Now.AddMinutes(DEFAULT_EXPIRE_TIME));
        }

        /// <summary>
        /// 新增缓存项
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="expireTime">过期时间</param>
        public void SetCache<T>(string key, T value, DateTime expireTime)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = expireTime;
            mc.Add(new CacheItem(key, value), policy);
        }

        /// <summary>
        /// 移除指定缓存项
        /// </summary>
        /// <param name="key">Key</param>
        public bool Remove(string key)
        {
            mc.Remove(key);
            return true;
        }

        /// <summary>
        /// 指定缓存Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return GetCache<object>(key) != null;
        }

        public void Dispose()
        {
            if (mc != null)
            {
                mc.Dispose();
            }
        }
    }
}
