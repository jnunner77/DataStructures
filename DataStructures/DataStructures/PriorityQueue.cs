using System;
using System.Collections;
namespace DataStructures
{
    public class PriorityQueue : IEnumerable, ICloneable
    {
        protected ArrayList internalQueue = new ArrayList();
        protected IComparer specialComparer = null;
        public int Count
        {
            get
            {
                return internalQueue.Count;
            }
        }
        public PriorityQueue()
        {

        }
        public PriorityQueue(IComparer icomparer)
        {
            specialComparer = icomparer;
        }
        public void Clear()
        {
            internalQueue.Clear();
        }
        public object Clone()
        {
            PriorityQueue newPQ = new PriorityQueue(specialComparer);
            newPQ.CopyTo(internalQueue.ToArray(), 0);
            return newPQ;
        }
        public int IndexOf(string str)
        {
            return internalQueue.BinarySearch(str);
        }
        public bool Contains(string str)
        {
            if(internalQueue.BinarySearch(str) >= 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public int BinarySearch(string str)
        {
            return internalQueue.BinarySearch(str, specialComparer);
        }
        public bool Contains(string str, IComparer specialComparer)
        {
            if(internalQueue.BinarySearch(str, specialComparer) >= 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public void CopyTo(Array array, int index)
        {
            internalQueue.CopyTo(array, index);
        }
        public virtual object[] ToArray()
        {
            return internalQueue.ToArray();
        }
        public virtual void TrimtoSize()
        {
            internalQueue.TrimToSize();
        }
        public void Enqueue(string str)
        {
            internalQueue.Add(str);
            internalQueue.Sort(specialComparer);
        }
        public string DequeueSmallest()
        {
            string s = (string)internalQueue[0];
            internalQueue.RemoveAt(0);
            return s;
        }
        public string DequeueLargest()
        {
            string s = (string)internalQueue[internalQueue.Count - 1];
            internalQueue.RemoveAt(internalQueue.Count - 1);
            return s;
        }
        public string PeekSmallest()
        {
            return (string)internalQueue[0];
        }
        public string PeekLargest()
        {
            return (string)internalQueue[internalQueue.Count - 1];
        }
        public IEnumerator GetEnumerator()
        {
            return internalQueue.GetEnumerator();
        }

    }
}
