using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStack<T>
    {
        private T[] items;

        private int size = 0;

        public MyStack()
        {
            items = new T[0];
        }

        public string Print()
        {
            string result = "";
            for (int i = 0; i < size; i++)
            {
                result += items[i] + " ";
            }

            return result;
        }

        public bool Empty()
        {
            return size == 0;
        }
        private void IncreaseArray()
        {
            int newCount = size * 2;
            if (size == 0)
            {
                newCount = 4;
            }

            T[] newArray = new T[newCount];
            for (int i = 0; i < size; i++)
            {
                newArray[i] = items[i];
            }

            items = newArray;
        }
        public void Push(T item)
        {
            if (size == items.Length)
            {
                IncreaseArray();
            }

            items[size] = item;
            size++;
        }
        public T Pop()
        {
            if (size == 0)
            {
                throw new Exception("Стек пустой.");
            }

            T lastItem = items[size - 1];
            size--;
            return lastItem;
        }
        public T Peek()
        {
            if (size == 0)
            {
                throw new Exception("Стек пустой.");
            }

            return items[size - 1];
        }
        public void Clear()
        {
            size = 0;
        }
    }
}
