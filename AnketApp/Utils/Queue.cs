using System;
using System.Collections.Generic;  // Bu kütüphane koleksiyonları (List, Dictionary) sağlar
using Newtonsoft.Json;  // JSON işlemleri için gerekli
using System.Linq;


namespace AnketApp.Utils
{
    public class Queue<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Enqueue(T value)
        {
            _list.AddLast(value);
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            var value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            return _list.First.Value;
        }

        public bool IsEmpty() => _list.Count == 0;
    }
}
