using System;
using System.Collections.Generic;  // Bu kütüphane koleksiyonları (List, Dictionary) sağlar
using Newtonsoft.Json;  // JSON işlemleri için gerekli
using System.Linq;


namespace AnketApp.Utils
{
    public class Stack<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T value)
        {
            _list.AddFirst(value);
        }

        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack is empty");
            var value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack is empty");
            return _list.First.Value;
        }

        public bool IsEmpty() => _list.Count == 0;
    }
}
