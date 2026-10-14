using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace List
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] _array = new T[4];
        private int _factualCount = 0;
        public int Count => _factualCount;
        public void Add(T elem)
        {
            var arrLength = _array.Length;
            if (_factualCount == arrLength)
            {
                var newArr = new T[arrLength * 2];
                for (int i = 0; i < arrLength; i++)
                {
                    newArr[i] = _array[i];
                }
                _array = newArr;
            }
            _array[_factualCount] = elem;
            _factualCount++;
        }
        public void RemoveAt(int index)
        {
            if (_factualCount == 0)
            {
                throw new Exception("You cannot remove elements from an empty list");
            }
            if (index >= _factualCount || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < _array.Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _factualCount--;
        }
        public string Print()
        {
            var res = "";
            var count = 0;
            while (count <= _factualCount)
            {
                res += _array[count] + " ";
                count++;
            }
            return res;
        }
        public bool Remove(T elem)
        {
            var index = -1;
            for (int i = 0; i < _factualCount; i++)
            {
                if (EqualityComparer<T>.Default.Equals(elem, _array[i]))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }
        public void AddRange(IEnumerable<T> elems)
        {
            foreach (var elem in elems)
            {
                Add(elem);
            }
        }
        public void Clear()
        {
            _factualCount = 0;
        }
        public void Insert(int index, T item)
        {
            if (_factualCount == 0)
            {
                throw new Exception("You cannot insert elements into an empty list");
            }
            if (index >= _factualCount || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_factualCount + 1 < _array.Length)
            {
                for (int i = index + 1; i < _factualCount + 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                var elem = _array[index];
            }
            else
            {
                var newArray = new T[_array.Length * 2];
                for (int i = 0; i < index; i++)
                {
                    newArray[i] = _array[i];
                }
                newArray[index] = item;
                for (int i = index; i < _array.Length; i++)
                {
                    newArray[i + 1] = _array[i];
                }
                _array = newArray;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (_factualCount == 0)
            {
                throw new Exception("You cannot enumerate an empty list");
            }
            for (int i = 0; i < _factualCount; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public T this[int index] { get { return index < _factualCount && index >= 0 ? _array[index] : throw new IndexOutOfRangeException(); } }
    }
}
