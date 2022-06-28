using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Map<TKey, TValue> where TKey, TValue : IComparable
    {
        private readonly LinkedList<KeyValuePair<TKey, TValue>>[] _items;
        private readonly int _size;

        public Map(int size)
        {
            this._size = size;
            _items = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }
        protected int getArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % _size;
            return Math.Abs(position);
        }
        public TValue Find(TKey key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            foreach(KeyValuePair<TKey, TValue> item in linkedList)
            {
                if(item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(TValue);
        }
        public void Add(TKey key, TValue value)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValuePair<TKey, TValue> foundItem = default(KeyValuePair<TKey, TValue>);
            foreach(KeyValuePair<TKey, TValue> item in linkedList)
            {
                if(item.Key.Equals(key))
                {
                    itemFound = item;
                    foundItem = true;
                }
            }
            if(itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        protected LinkedList<KeyValuePair<TKey, TValue>> GetLinkedList(int position)
        {
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = _items[position];
            if(linkedList == null)
            {
                linkedList = new LinkedList<KeyValuePair<TKey, TValue>>();
                _items[position] = linkedList;
            }
            return linkedList;
        }
    }
}