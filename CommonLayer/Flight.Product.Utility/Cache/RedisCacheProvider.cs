using ServiceStack.Redis;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Flight.Product.Utility
{
    /// <summary>
    /// 分布式缓存Redis
    /// </summary>
    public class RedisCacheProvider : ICacheProvider, IRedis
    {
        RedisClient redisClient;
        public string RedisServerIP { get; set; }
        public RedisCacheProvider() { }
        public RedisCacheProvider(string redisServerIP)
        {
            this.RedisServerIP = redisServerIP;
            redisClient = new RedisClient(redisServerIP);
        }

        #region ICacheProvider
        /// <summary>
        /// 默认缓存过期时间，单位分钟，默认10分钟
        /// </summary>
        const int DEFAULT_EXPIRE_TIME = 10;
        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <param name="key">缓存KEY</param>
        /// <returns></returns>
        public T GetCache<T>(string key)
        {
            return this.Get<T>(key);
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
            this.Set<T>(key, value, expireTime);
        }

        /// <summary>
        /// 移除指定缓存项
        /// </summary>
        /// <param name="key">Key</param>
        //public void Remove(string key)
        //{
        //    this.Remove(key);
        //}

        /// <summary>
        /// 指定缓存Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return this.ContainsKey(key);
        }
        #endregion

        #region IRedis
        public bool Replace<T>(string key, T value)
        {
            return redisClient.Replace<T>(key, value);
        }
        public bool Replace<T>(string key, T value, DateTime expiresAt)
        {
            return redisClient.Replace<T>(key, value, expiresAt);
        }
        public bool Replace<T>(string key, T value, TimeSpan expiresIn)
        {
            return redisClient.Replace<T>(key, value, expiresIn);
        }
        public void RewriteAppendOnlyFileAsync()
        {
            redisClient.RewriteAppendOnlyFileAsync();
        }
        public List<string> SearchKeys(string pattern)
        {
            return redisClient.SearchKeys(pattern);
        }
        public bool Set<T>(string key, T value)
        {
            return redisClient.Set<T>(key, value);
        }
        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            return redisClient.Set<T>(key, value, expiresAt);
        }
        public bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            return redisClient.Set<T>(key, value, expiresIn);
        }
        public void SetAll(Dictionary<string, string> map)
        {
            redisClient.SetAll(map);
        }
        public void SetAll<T>(IDictionary<string, T> values)
        {
            redisClient.SetAll<T>(values);
        }
        public void SetAll(IEnumerable<string> keys, IEnumerable<string> values)
        {
            redisClient.SetAll(keys, values);
        }
        public void SetConfig(string configItem, string value)
        {
            redisClient.SetConfig(configItem, value);
        }
        public bool SetContainsItem(string setId, string item)
        {
            return redisClient.SetContainsItem(setId, item);
        }
        public void SetEntry(string key, string value)
        {
            redisClient.SetEntry(key, value);
        }
        public void SetEntry(string key, string value, TimeSpan expireIn)
        {
            redisClient.SetEntry(key, value, expireIn);
        }
        public void SetEntryIfExists(string key, string value, TimeSpan expireIn)
        {
            redisClient.SetEntryIfExists(key, value, expireIn);
        }
        public bool SetEntryIfNotExists(string key, string value)
        {
            return redisClient.SetEntryIfNotExists(key, value);
        }
        public void SetEntryIfNotExists(string key, string value, TimeSpan expireIn)
        {
            redisClient.SetEntryIfNotExists(key, value, expireIn);
        }
        public bool SetEntryInHash(string hashId, string key, string value)
        {
            return redisClient.SetEntryInHash(hashId, key, value);
        }
        public bool SetEntryInHashIfNotExists(string hashId, string key, string value)
        {
            return redisClient.SetEntryInHashIfNotExists(hashId, key, value);
        }
        public void SetItemInList(string listId, int listIndex, string value)
        {
            redisClient.SetItemInList(listId, listIndex, value);
        }
        public void SetRangeInHash(string hashId, IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            redisClient.SetRangeInHash(hashId, keyValuePairs);
        }
        public bool SortedSetContainsItem(string setId, string value)
        {
            return redisClient.SortedSetContainsItem(setId, value);
        }
        public T Store<T>(T entity)
        {
            return redisClient.Store<T>(entity);
        }
        public void StoreAll<T>(IEnumerable<T> entities)
        {
            redisClient.StoreAll<T>(entities);
        }
        public void StoreAsHash<T>(T entity)
        {
            redisClient.StoreAsHash<T>(entity);
        }
        public void StoreDifferencesFromSet(string intoSetId, string fromSetId, string[] withSetIds)
        {
            redisClient.StoreDifferencesFromSet(intoSetId, fromSetId, withSetIds);
        }
        public void StoreIntersectFromSets(string intoSetId, string[] setIds)
        {
            redisClient.StoreIntersectFromSets(intoSetId, setIds);
        }
        public long StoreIntersectFromSortedSets(string intoSetId, string[] setIds)
        {
            return redisClient.StoreIntersectFromSortedSets(intoSetId, setIds);
        }
        public object StoreObject(object entity)
        {
            return redisClient.StoreObject(entity);
        }
        public void StoreUnionFromSets(string intoSetId, string[] setIds)
        {
            redisClient.StoreUnionFromSets(intoSetId, setIds);
        }
        public long StoreUnionFromSortedSets(string intoSetId, string[] setIds)
        {
            return redisClient.StoreUnionFromSortedSets(intoSetId, setIds);
        }
        public void TrimList(string listId, int keepStartingFrom, int keepEndingAt)
        {
            redisClient.TrimList(listId, keepStartingFrom, keepEndingAt);
        }
        public Dictionary<string, bool> WhichLuaScriptsExists(string[] sha1Refs)
        {
            return redisClient.WhichLuaScriptsExists(sha1Refs);
        }
        public void WriteAll<TEntity>(IEnumerable<TEntity> entities)
        {
            redisClient.WriteAll<TEntity>(entities);
        }
        public List<string> GetRangeFromSortedSetByHighestScore(string setId, long fromScore, long toScore)
        {
            return redisClient.GetRangeFromSortedSetByHighestScore(setId, fromScore, toScore);
        }
        public List<string> GetRangeFromSortedSetByHighestScore(string setId, string fromStringScore, string toStringScore)
        {
            return redisClient.GetRangeFromSortedSetByHighestScore(setId, fromStringScore, toStringScore);
        }
        public List<string> GetRangeFromSortedSetByHighestScore(string setId, double fromScore, double toScore, int? skip, int? take)
        {
            return redisClient.GetRangeFromSortedSetByHighestScore(setId, fromScore, toScore, skip, take);
        }
        public List<string> GetRangeFromSortedSetByHighestScore(string setId, long fromScore, long toScore, int? skip, int? take)
        {
            return redisClient.GetRangeFromSortedSetByHighestScore(setId, fromScore, toScore, skip, take);
        }
        public List<string> GetRangeFromSortedSetByHighestScore(string setId, string fromStringScore, string toStringScore, int? skip, int? take)
        {
            return redisClient.GetRangeFromSortedSetByHighestScore(setId, fromStringScore, toStringScore, skip, take);
        }
        public List<string> GetRangeFromSortedSetByLowestScore(string setId, double fromScore, double toScore)
        {
            return redisClient.GetRangeFromSortedSetByLowestScore(setId, fromScore, toScore);
        }
        public List<string> GetRangeFromSortedSetByLowestScore(string setId, long fromScore, long toScore)
        {
            return redisClient.GetRangeFromSortedSetByLowestScore(setId, fromScore, toScore);
        }
        public List<string> GetRangeFromSortedSetByLowestScore(string setId, string fromStringScore, string toStringScore)
        {
            return redisClient.GetRangeFromSortedSetByLowestScore(setId, fromStringScore, toStringScore);
        }
        public List<string> GetRangeFromSortedSetByLowestScore(string setId, double fromScore, double toScore, int? skip, int? take)
        {
            return redisClient.GetRangeFromSortedSetByLowestScore(setId, fromScore, toScore, skip, take);
        }
        public List<string> GetRangeFromSortedSetByLowestScore(string setId, long fromScore, long toScore, int? skip, int? take)
        {
            return redisClient.GetRangeFromSortedSetByLowestScore(setId, fromScore, toScore, skip, take);
        }
        public List<string> GetRangeFromSortedSetByLowestScore(string setId, string fromStringScore, string toStringScore, int? skip, int? take)
        {
            return redisClient.GetRangeFromSortedSetByLowestScore(setId, fromStringScore, toStringScore, skip, take);
        }
        public List<string> GetRangeFromSortedSetDesc(string setId, int fromRank, int toRank)
        {
            return redisClient.GetRangeFromSortedSetDesc(setId, fromRank, toRank);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSet(string setId, int fromRank, int toRank)
        {
            return redisClient.GetRangeWithScoresFromSortedSet(setId, fromRank, toRank);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, double fromScore, double toScore)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, long fromScore, long toScore)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, string fromStringScore, string toStringScore)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromStringScore, toStringScore);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, double fromScore, double toScore, int? skip, int? take)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore, skip, take);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, long fromScore, long toScore, int? skip, int? take)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromScore, toScore, skip, take);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string setId, string fromStringScore, string toStringScore, int? skip, int? take)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByHighestScore(setId, fromStringScore, toStringScore, skip, take);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, double fromScore, double toScore)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromScore, toScore);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, long fromScore, long toScore)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromScore, toScore);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, string fromStringScore, string toStringScore)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromStringScore, toStringScore);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, double fromScore, double toScore, int? skip, int? take)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromScore, toScore, skip, take);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, long fromScore, long toScore, int? skip, int? take)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromScore, toScore, skip, take);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string setId, string fromStringScore, string toStringScore, int? skip, int? take)
        {
            return redisClient.GetRangeWithScoresFromSortedSetByLowestScore(setId, fromStringScore, toStringScore, skip, take);
        }
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string setId, int fromRank, int toRank)
        {
            return redisClient.GetRangeWithScoresFromSortedSetDesc(setId, fromRank, toRank);
        }
        public long GetSetCount(string setId)
        {
            return redisClient.GetSetCount(setId);
        }
        public List<string> GetSortedEntryValues(string setId, int startingFrom, int endingAt)
        {
            return redisClient.GetSortedEntryValues(setId, startingFrom, endingAt);
        }
        public long GetSortedSetCount(string setId)
        {
            return redisClient.GetSortedSetCount(setId);
        }
        public long GetSortedSetCount(string setId, double fromScore, double toScore)
        {
            return redisClient.GetSortedSetCount(setId, fromScore, toScore);
        }
        public long GetSortedSetCount(string setId, long fromScore, long toScore)
        {
            return redisClient.GetSortedSetCount(setId, fromScore, toScore);
        }
        public long GetSortedSetCount(string setId, string fromStringScore, string toStringScore)
        {
            return redisClient.GetSortedSetCount(setId, fromStringScore, toStringScore);
        }
        public TimeSpan? GetTimeToLive(string key)
        {
            return redisClient.GetTimeToLive(key);
        }
        public string GetTypeIdsSetKey<T>()
        {
            return redisClient.GetTypeIdsSetKey<T>();
        }
        public string GetTypeIdsSetKey(Type type)
        {
            return redisClient.GetTypeIdsSetKey(type);
        }
        public string GetTypeSequenceKey<T>()
        {
            return redisClient.GetTypeSequenceKey<T>();
        }
        public HashSet<string> GetUnionFromSets(string[] setIds)
        {
            return redisClient.GetUnionFromSets(setIds);
        }
        public string GetValue(string key)
        {
            return redisClient.GetValue(key);
        }
        public string GetValueFromHash(string hashId, string key)
        {
            return redisClient.GetValueFromHash(hashId, key);
        }
        public List<T> GetValues<T>(List<string> keys)
        {
            return redisClient.GetValues<T>(keys);
        }
        public List<string> GetValues(List<string> keys)
        {
            return redisClient.GetValues(keys);
        }
        public List<string> GetValuesFromHash(string hashId, string[] keys)
        {
            return redisClient.GetValuesFromHash(hashId, keys);
        }
        public Dictionary<string, string> GetValuesMap(List<string> keys)
        {
            return redisClient.GetValuesMap(keys);
        }
        public Dictionary<string, T> GetValuesMap<T>(List<string> keys)
        {
            return redisClient.GetValuesMap<T>(keys);
        }
        public bool HashContainsEntry(string hashId, string key)
        {
            return redisClient.HashContainsEntry(hashId, key);
        }
        public bool HasLuaScript(string sha1Ref)
        {
            return redisClient.HasLuaScript(sha1Ref);
        }
        public long Increment(string key, UInt32 amount)
        {
            return redisClient.Increment(key, amount);
        }
        public double IncrementItemInSortedSet(string setId, string value, double incrementBy)
        {
            return redisClient.IncrementItemInSortedSet(setId, value, incrementBy);
        }
        public double IncrementItemInSortedSet(string setId, string value, long incrementBy)
        {
            return redisClient.IncrementItemInSortedSet(setId, value, incrementBy);
        }
        public long IncrementValue(string key)
        {
            return redisClient.IncrementValue(key);
        }
        public long IncrementValueBy(string key, int count)
        {
            return redisClient.IncrementValueBy(key, count);
        }
        public long IncrementValueInHash(string hashId, string key, int incrementBy)
        {
            return redisClient.IncrementValueInHash(hashId, key, incrementBy);
        }
        public long IncrementValueInHash(string hashId, string key, long incrementBy)
        {
            return redisClient.IncrementValueInHash(hashId, key, incrementBy);
        }
        public void Init()
        {
            redisClient.Init();
        }
        public void KillRunningLuaScript()
        {
            redisClient.KillRunningLuaScript();
        }
        public string LoadLuaScript(string body)
        {
            return redisClient.LoadLuaScript(body);
        }
        public void MoveBetweenSets(string fromSetId, string toSetId, string item)
        {
            redisClient.MoveBetweenSets(fromSetId, toSetId, item);
        }
        public string PopAndPushItemBetweenLists(string fromListId, string toListId)
        {
            return redisClient.PopAndPushItemBetweenLists(fromListId, toListId);
        }
        public string PopItemFromList(string listId)
        {
            return redisClient.PopItemFromList(listId);
        }
        public string PopItemFromSet(string setId)
        {
            return redisClient.PopItemFromSet(setId);
        }
        public string PopItemWithHighestScoreFromSortedSet(string setId)
        {
            return redisClient.PopItemWithHighestScoreFromSortedSet(setId);
        }
        public string PopItemWithLowestScoreFromSortedSet(string setId)
        {
            return redisClient.PopItemWithLowestScoreFromSortedSet(setId);
        }
        public void PrependItemToList(string listId, string value)
        {
            redisClient.PrependItemToList(listId, value);
        }
        public void PrependRangeToList(string listId, List<string> values)
        {
            redisClient.PrependRangeToList(listId, values);
        }
        public long PublishMessage(string toChannel, string message)
        {
            return redisClient.PublishMessage(toChannel, message);
        }
        public void PushItemToList(string listId, string value)
        {
            redisClient.PushItemToList(listId, value);
        }
        public bool Remove(string key)
        {
            return redisClient.Remove(key);
        }
        public void RemoveAll(IEnumerable<string> keys)
        {
            redisClient.RemoveAll(keys);
        }
        public void RemoveAllFromList(string listId)
        {
            redisClient.RemoveAllFromList(listId);
        }
        public void RemoveAllLuaScripts()
        {
            redisClient.RemoveAllLuaScripts();
        }
        public string RemoveEndFromList(string listId)
        {
            return redisClient.RemoveEndFromList(listId);
        }
        public bool RemoveEntry(string[] keys)
        {
            return redisClient.RemoveEntry(keys);
        }
        public bool RemoveEntryFromHash(string hashId, string key)
        {
            return redisClient.RemoveEntryFromHash(hashId, key);
        }
        public long RemoveItemFromList(string listId, string value)
        {
            return redisClient.RemoveItemFromList(listId, value);
        }
        public long RemoveItemFromList(string listId, string value, int noOfMatches)
        {
            return redisClient.RemoveItemFromList(listId, value, noOfMatches);
        }
        public void RemoveItemFromSet(string setId, string item)
        {
            redisClient.RemoveItemFromSet(setId, item);
        }
        public bool RemoveItemFromSortedSet(string setId, string value)
        {
            return redisClient.RemoveItemFromSortedSet(setId, value);
        }
        public long RemoveRangeFromSortedSet(string setId, int minRank, int maxRank)
        {
            return redisClient.RemoveRangeFromSortedSet(setId, minRank, maxRank);
        }
        public long RemoveRangeFromSortedSetByScore(string setId, double fromScore, double toScore)
        {
            return redisClient.RemoveRangeFromSortedSetByScore(setId, fromScore, toScore);
        }
        public long RemoveRangeFromSortedSetByScore(string setId, long fromScore, long toScore)
        {
            return redisClient.RemoveRangeFromSortedSetByScore(setId, fromScore, toScore);
        }
        public string RemoveStartFromList(string listId)
        {
            return redisClient.RemoveStartFromList(listId);
        }
        public void RenameKey(string fromName, string toName)
        {
            redisClient.RenameKey(fromName, toName);
        }
        public IDisposable AcquireLock(string key)
        {
            return redisClient.AcquireLock(key);
        }
        public IDisposable AcquireLock(string key, TimeSpan timeOut)
        {
            return redisClient.AcquireLock(key, timeOut);
        }
        public bool Add<T>(string key, T value)
        {
            return redisClient.Add<T>(key, value);
        }
        public bool Add<T>(string key, T value, DateTime expiresAt)
        {
            return redisClient.Add<T>(key, value, expiresAt);
        }
        public bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            return redisClient.Add<T>(key, value, expiresIn);
        }
        public void AddItemToList(string listId, string value)
        {
            redisClient.AddItemToList(listId, value);
        }
        public void AddItemToSet(string setId, string item)
        {
            redisClient.AddItemToSet(setId, item);
        }
        public bool AddItemToSortedSet(string setId, string value)
        {
            return redisClient.AddItemToSortedSet(setId, value);
        }
        public bool AddItemToSortedSet(string setId, string value, double score)
        {
            return redisClient.AddItemToSortedSet(setId, value, score);
        }
        public bool AddItemToSortedSet(string setId, string value, long score)
        {
            return redisClient.AddItemToSortedSet(setId, value, score);
        }
        public void AddRangeToList(string listId, List<string> values)
        {
            redisClient.AddRangeToList(listId, values);
        }
        public void AddRangeToSet(string setId, List<string> items)
        {
            redisClient.AddRangeToSet(setId, items);
        }
        public bool AddRangeToSortedSet(string setId, List<string> values, double score)
        {
            return redisClient.AddRangeToSortedSet(setId, values, score);
        }
        public bool AddRangeToSortedSet(string setId, List<string> values, long score)
        {
            return redisClient.AddRangeToSortedSet(setId, values, score);
        }
        public long AppendToValue(string key, string value)
        {
            return redisClient.AppendToValue(key, value);
        }
        public string BlockingDequeueItemFromList(string listId, TimeSpan? timeOut)
        {
            return redisClient.BlockingDequeueItemFromList(listId, timeOut);
        }
        public string BlockingPopAndPushItemBetweenLists(string fromListId, string toListId, TimeSpan? timeOut)
        {
            return redisClient.BlockingPopAndPushItemBetweenLists(fromListId, toListId, timeOut);
        }
        public string BlockingPopItemFromList(string listId, TimeSpan? timeOut)
        {
            return redisClient.BlockingPopItemFromList(listId, timeOut);
        }
        public string BlockingRemoveStartFromList(string listId, TimeSpan? timeOut)
        {
            return redisClient.BlockingRemoveStartFromList(listId, timeOut);
        }
        public void ChangeDb(long db)
        {
            redisClient.ChangeDb(db);
        }
        public bool ContainsKey(string key)
        {
            return redisClient.ContainsKey(key);
        }
        public long Decrement(string key, UInt32 amount)
        {
            return redisClient.Decrement(key, amount);
        }
        public long DecrementValue(string key)
        {
            return redisClient.DecrementValue(key);
        }
        public long DecrementValueBy(string key, int count)
        {
            return redisClient.DecrementValueBy(key, count);
        }
        public void Delete<T>(T entity)
        {
            redisClient.Delete<T>(entity);
        }
        public void DeleteAll<T>()
        {
            redisClient.DeleteAll<T>();
        }
        public void DeleteById<T>(object id)
        {
            redisClient.DeleteById<T>(id);
        }
        public void DeleteByIds<T>(ICollection ids)
        {
            redisClient.DeleteByIds<T>(ids);
        }
        public string DequeueItemFromList(string listId)
        {
            return redisClient.DequeueItemFromList(listId);
        }
        public void EnqueueItemOnList(string listId, string value)
        {
            redisClient.EnqueueItemOnList(listId, value);
        }
        public long ExecLuaAsInt(string body, string[] args)
        {
            return redisClient.ExecLuaAsInt(body, args);
        }
        public long ExecLuaAsInt(string luaBody, string[] keys, string[] args)
        {
            return redisClient.ExecLuaAsInt(luaBody, keys, args);
        }
        public List<string> ExecLuaAsList(string body, string[] args)
        {
            return redisClient.ExecLuaAsList(body, args);
        }
        public List<string> ExecLuaAsList(string luaBody, string[] keys, string[] args)
        {
            return redisClient.ExecLuaAsList(luaBody, keys, args);
        }
        public string ExecLuaAsString(string body, string[] args)
        {
            return redisClient.ExecLuaAsString(body, args);
        }
        public string ExecLuaAsString(string sha1, string[] keys, string[] args)
        {
            return redisClient.ExecLuaAsString(sha1, keys, args);
        }
        public long ExecLuaShaAsInt(string sha1, string[] args)
        {
            return redisClient.ExecLuaShaAsInt(sha1, args);
        }
        public long ExecLuaShaAsInt(string sha1, string[] keys, string[] args)
        {
            return redisClient.ExecLuaShaAsInt(sha1, keys, args);
        }
        public List<string> ExecLuaShaAsList(string sha1, string[] args)
        {
            return redisClient.ExecLuaShaAsList(sha1, args);
        }
        public List<string> ExecLuaShaAsList(string sha1, string[] keys, string[] args)
        {
            return redisClient.ExecLuaShaAsList(sha1, keys, args);
        }
        public string ExecLuaShaAsString(string sha1, string[] args)
        {
            return redisClient.ExecLuaShaAsString(sha1, args);
        }
        public string ExecLuaShaAsString(string sha1, string[] keys, string[] args)
        {
            return redisClient.ExecLuaShaAsString(sha1, keys, args);
        }
        public bool ExpireEntryAt(string key, DateTime expireAt)
        {
            return redisClient.ExpireEntryAt(key, expireAt);
        }
        public bool ExpireEntryIn(string key, TimeSpan expireIn)
        {
            return redisClient.ExpireEntryIn(key, expireIn);
        }
        public T Get<T>(string key)
        {
            //using (RedisClient redisClient = new RedisClient(this.RedisServerIP))
            return redisClient.Get<T>(key);
        }
        public IList<T> GetAll<T>()
        {
            return redisClient.GetAll<T>();
        }
        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            return redisClient.GetAll<T>(keys);
        }
        public Dictionary<string, string> GetAllEntriesFromHash(string hashId)
        {
            return redisClient.GetAllEntriesFromHash(hashId);
        }
        public List<string> GetAllItemsFromList(string listId)
        {
            return redisClient.GetAllItemsFromList(listId);
        }
        public HashSet<string> GetAllItemsFromSet(string setId)
        {
            return redisClient.GetAllItemsFromSet(setId);
        }
        public List<string> GetAllItemsFromSortedSet(string setId)
        {
            return redisClient.GetAllItemsFromSortedSet(setId);
        }
        public List<string> GetAllItemsFromSortedSetDesc(string setId)
        {
            return redisClient.GetAllItemsFromSortedSetDesc(setId);
        }
        public List<string> GetAllKeys()
        {
            return redisClient.GetAllKeys();
        }
        public IDictionary<string, double> GetAllWithScoresFromSortedSet(string setId)
        {
            return redisClient.GetAllWithScoresFromSortedSet(setId);
        }
        public string GetAndSetEntry(string key, string value)
        {
            return redisClient.GetAndSetEntry(key, value);
        }
        public T GetById<T>(object id)
        {
            return redisClient.GetById<T>(id);
        }
        public IList<T> GetByIds<T>(ICollection ids)
        {
            return redisClient.GetByIds<T>(ids);
        }
        public List<Dictionary<string, string>> GetClientList()
        {
            return redisClient.GetClientList();
        }
        public string GetConfig(string configItem)
        {
            return redisClient.GetConfig(configItem);
        }
        public HashSet<string> GetDifferencesFromSet(string fromSetId, string[] withSetIds)
        {
            return redisClient.GetDifferencesFromSet(fromSetId, withSetIds);
        }
        public T GetFromHash<T>(object id)
        {
            return redisClient.GetFromHash<T>(id);
        }
        public long GetHashCount(string hashId)
        {
            return redisClient.GetHashCount(hashId);
        }
        public List<string> GetHashKeys(string hashId)
        {
            return redisClient.GetHashKeys(hashId);
        }
        public List<string> GetHashValues(string hashId)
        {
            return redisClient.GetHashValues(hashId);
        }
        public HashSet<string> GetIntersectFromSets(string[] setIds)
        {
            return redisClient.GetIntersectFromSets(setIds);
        }
        public string GetItemFromList(string listId, int listIndex)
        {
            return redisClient.GetItemFromList(listId, listIndex);
        }
        public long GetItemIndexInSortedSet(string setId, string value)
        {
            return redisClient.GetItemIndexInSortedSet(setId, value);
        }
        public long GetItemIndexInSortedSetDesc(string setId, string value)
        {
            return redisClient.GetItemIndexInSortedSetDesc(setId, value);
        }
        public double GetItemScoreInSortedSet(string setId, string value)
        {
            return redisClient.GetItemScoreInSortedSet(setId, value);
        }
        public long GetListCount(string listId)
        {
            return redisClient.GetListCount(listId);
        }
        public string GetRandomItemFromSet(string setId)
        {
            return redisClient.GetRandomItemFromSet(setId);
        }
        public string GetRandomKey()
        {
            return redisClient.GetRandomKey();
        }
        public List<string> GetRangeFromList(string listId, int startingFrom, int endingAt)
        {
            return redisClient.GetRangeFromList(listId, startingFrom, endingAt);
        }
        public List<string> GetRangeFromSortedList(string listId, int startingFrom, int endingAt)
        {
            return redisClient.GetRangeFromSortedList(listId, startingFrom, endingAt);
        }
        public List<string> GetRangeFromSortedSet(string setId, int fromRank, int toRank)
        {
            return redisClient.GetRangeFromSortedSet(setId, fromRank, toRank);
        }
        public List<string> GetRangeFromSortedSetByHighestScore(string setId, double fromScore, double toScore)
        {
            return redisClient.GetRangeFromSortedSetByHighestScore(setId, fromScore, toScore);
        }
        #endregion

        ~RedisCacheProvider()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (redisClient != null)
            {
                redisClient.Dispose();
            }
        }
    }
}
