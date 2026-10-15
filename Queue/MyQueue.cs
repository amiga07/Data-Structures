using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class MyQueue<T>
    {
        private List<T> items;

        public MyQueue()
        {
            items = new List<T>();
        }

        public string Print()
        {
            string result = "";
            foreach (var item in items)
            {
                result += item + " ";
            }

            return result;
        }

        public bool Empty()
        {
            return items.Count == 0;
        }
        public void Push(T item)
        {
            items.Add(item);
        }
        public T Pop()
        {
            if (items.Count == 0)
            {
                throw new Exception("Очередь пустая.");
            }

            T lastItem = items[0];
            items.RemoveAt(0);
            return lastItem;
        }
        public T Peek()
        {
            if (items.Count == 0)
            {
                throw new Exception("Очередь пустая.");
            }

            return items[0];
        }
        public void Clear()
        {
            items.Clear();
        }
    }
}
