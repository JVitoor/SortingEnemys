using SortingEnemys.enemys;
using System.Collections.Generic;

namespace SortingEnemys.estruturas
{
    public class HashNode
    {
        public string Key { get; set; }
        public Enemy Value { get; set; }

        public HashNode(string key, Enemy value)
        {
            Key = key;
            Value = value;
        }
    }

    public class HashTable
    {
        private readonly int size;
        private readonly LinkedList<HashNode>[] buckets;

        public HashTable(int size)
        {
            this.size = size;
            buckets = new LinkedList<HashNode>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new LinkedList<HashNode>();
            }
        }

        private int GetBucketIndex(string key)
        {
            int hashCode = key.GetHashCode();
            int index = System.Math.Abs(hashCode % size);
            return index;
        }

        public void Add(string key, Enemy value)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            foreach (var node in bucket)
            {
                if (node.Key.Equals(key))
                {
                    node.Value = value;
                    return;
                }
            }

            bucket.AddLast(new HashNode(key, value));
        }

        public Enemy Get(string key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            foreach (var node in bucket)
            {
                if (node.Key.Equals(key))
                {
                    return node.Value;
                }
            }

            return null;
        }

        public void Remove(string key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];
            HashNode toRemove = null;

            foreach (var node in bucket)
            {
                if (node.Key.Equals(key))
                {
                    toRemove = node;
                    break;
                }
            }

            if (toRemove != null)
            {
                bucket.Remove(toRemove);
            }
        }
    }
}