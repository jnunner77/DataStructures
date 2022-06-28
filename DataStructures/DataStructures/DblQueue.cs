using System;
using System.Collections;

[Serializable]

public class DblQueue<T> : ICollection, IEnumerable, ICloneable
{
	protected ArrayList internalList = null;
	public DblQueue()
	{
		internalList = new ArrayList();
	}
	public DblQueue(ICollection collection)
    {
		internalList = new ArrayList(collection)
    }
	public virtual int Count
    {
        get
        {
			return internalList.Count;
        }
    }
	public virtual bool isSynchronized
    {
        get
        {
            return false;
        }
    }
    public virtual T SyncRoot
    {
        get
        {
            return this;
        }
    }
    public static DblQueue Synchronized(DblQueue dqueue)
    {
        if(dqueue == null)
        {
            throw new ArgumentNullException("Double queue is null");
        }
        return new SyncDeQueue(dqueue);
    }
    public virtual void Clear()
    {
        internalList.Clear();
    }
    public virtual T Clone()
    {
        DblQueue newDQ = new DblQueue(this);
        return newDQ;
    }
    public virtual bool Contains(T obj)
    {
        return internalList.Contains(obj);
    }
    public virtual void CopyTo(Array array, int index)
    {
        internalList.CopyTo(array, index);
    }
    public virtual T dequeueHead()
    {
        T retObj = internalList[0];
        internalList.RemoveAt(0);
        return retObj;
    }
    public virtual T dequeueTail()
    {
        T retObj = internalList[internalList.Count - 1];
        internalList.RemoveAt(internalList.Count - 1);
        return retObj; 
    }
    public virtual void EnqueueHead(T obj)
    {
        internalList.Insert(0, obj);
    }
    public virtual void EnqueueTail(T obj)
    {
        internalList.Add(obj);
    }
    public virtual T PeekHead()
    {
        return internalList[0];
    }
    public virtual T PeekTail()
    {
        return internalList[internalList.Count - 1];
    }
    public virtual IEnumerator GetEnumerator()
    {
        return internalList.GetEnumerator();
    }
    public virtual T[] ToArray()
    {
        return internalList.ToArray();
    }
    public virtual void TrimToSize()
    {
        internalList.TrimToSize();
    }
    [Serializable]
    public class SyncDeQueue<T> : DblQueue
    {
        private DblQueue wrappedQ = null;
        private T root = null;
        public SyncDeQueue(DblQueue q)
        {
            wrappedQ = q;
            root = q.SyncRoot;
        }
        public override bool IsSynchronized
        {
            get
            {
                return true;
            }
        }
        public override int Count
        {
            get
            {
                lock(this)
                {
                    return wrappedQ.Count;
                }
            }
        }
        public override T SyncRoot
        {
            get
            {
                return root;
            }
        }
        public ovverride void Clear()
        {
            lock(this)
            {
                wrappedQ.Clear();
            }
        }
        public override T Clone()
        {
            lock(this)
            {
                return this.MemberwiseClone();
            }
        }
        public override bool Contains(T obj)
        {
            lock(this)
            {
                return wrappedQ.Contains(obj);
            }
        }
        public override void CopyTo(Array array, int index)
        {
            lock(this)
            {
                wrappedQ.CopyTo(array, index); 
            }
        }
        public override T DequeueHead()
        {
            lock(this)
            {
                return wrappedQ.dequeueHead();
            }
        }
        public override T DequeueTail()
        {
            lock(this)
            {
                return wrappedQ.dequeueTail();
            }
        }
        public override void EnqueueHead(T obj)
        {
            lock(this)
            {
                wrappedQ.EnqueueHead(obj);
            }
        }
        public override void EnqueueTail(T obj)
        {
            lock(this)
            {
                wrappedQ.EnqueueTail(obj);
            }
        }
        public override T PeekHead()
        {
            lock(this)
            {
                return wrappedQ.PeekHead();
            }
        }
        public override T PeekTail()
        {
            lock(this)
            {
                return wrappedQ.PeekTail();
            }
        }
        public override IEnumerator GetEnumerator()
        {
            lock(this)
            {
                return wrappedQ.GetEnumerator();
            }
        }
        public override T[] ToArray()
        {
            lock(this)
            {
                return wrappedQ.ToArray();
            }
        }
        public override void TrimToSize()
        {
            lock(this)
            {
                wrappedQ.TrimToSize();
            }
        }
    }

}
