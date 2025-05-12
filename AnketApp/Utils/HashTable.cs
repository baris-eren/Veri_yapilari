using System;
using System.Collections.Generic;  // Bu kütüphane koleksiyonları (List, Dictionary) sağlar
using Newtonsoft.Json;  // JSON işlemleri için gerekli
using System.Linq;


namespace AnketApp.Utils
{
    public class HashTable<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>>[] _buckets;

        public HashTable(int size)
        {
            _buckets = new List<KeyValuePair<TKey, TValue>>[size];
            for (int i = 0; i < size; i++)
            {
                _buckets[i] = new List<KeyValuePair<TKey, TValue>>();
            }
        }

        private int GetBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % _buckets.Length;
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);
            var bucket = _buckets[index];
            foreach (var pair in bucket)
            {
                if (EqualityComparer<TKey>.Default.Equals(pair.Key, key))
                {
                    throw new InvalidOperationException("Key already exists");
                }
            }
            bucket.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public TValue Get(TKey key)
        {
            int index = GetBucketIndex(key);
            var bucket = _buckets[index];
            foreach (var pair in bucket)
            {
                if (EqualityComparer<TKey>.Default.Equals(pair.Key, key))
                {
                    return pair.Value;
                }
            }
            throw new KeyNotFoundException("Key not found");
        }

        public bool ContainsKey(TKey key)
        {
            int index = GetBucketIndex(key);
            var bucket = _buckets[index];
            return bucket.Any(pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key));
        }
    }
}
