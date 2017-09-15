using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flight.Product.Utility
{
    /// <summary>
    /// 通用缓存接口
    /// </summary>
    public interface ICacheProvider : IDisposable
    {
        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <returns></returns>
        T GetCache<T>(string key);

        /// <summary>
        /// 新增缓存项
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        void SetCache<T>(string key, T value);

        /// <summary>
        /// 新增缓存项
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="expireTime">过期时间</param>
        void SetCache<T>(string key, T value, DateTime expireTime);

        /// <summary>
        /// 移除指定缓存项
        /// </summary>
        /// <param name="key">Key</param>
        bool Remove(string key);

        /// <summary>
        /// 指定缓存Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);
    }
}
