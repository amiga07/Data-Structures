using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    public class MyDictionary<TKey, TValue> : IEnumerable<(TKey, TValue)>
    {
        private List<(TKey, TValue)>[] _dictionary { get; set; }
        private int _count = 0;
        public int Count => _count;
        public MyDictionary()
        {
            _dictionary = new List<(TKey, TValue)>[16];
            for (int i = 0; i < _dictionary.Length; i++)
            {
                _dictionary[i] = new List<(TKey, TValue)>();
            }
        }
        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException();
            var flag = false;
            foreach (var elem in _dictionary)
            {
                for (int i = 0; i < elem.Count; i++)
                {
                    var tuple = elem[i];
                    if (tuple.Item1.Equals(key))
                    {
                        tuple.Item2 = value;
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                _count++;
                var code = (key.GetHashCode() & 0x7FFFFFFF) % _dictionary.Length;
                if (_count + 1 > _dictionary.Length)
                {
                    Resize();
                }
                _dictionary[code].Add((key, value));
            }
        }
        private void Resize()
        {
            var newTable = new List<(TKey, TValue)>[_dictionary.Length * 2];
            for (int i = 0; i < _dictionary.Length; i++)
            {
                newTable[i] = _dictionary[i];
            }
            for (int i = _dictionary.Length - 1; i < newTable.Length; i++)
            {
                newTable[i] = new List<(TKey, TValue)>();
            }
            _dictionary = newTable;
        }
        public TValue GetValue(TKey key)
        {
            var code = (key.GetHashCode() & 0x7FFFFFFF) % _dictionary.Length;
            if (_dictionary[code] != null && key != null)
            {
                foreach (var tuple in _dictionary[code])
                {
                    if (tuple.Item1.Equals(key)) return tuple.Item2;
                }
            }
            throw new KeyNotFoundException();
        }
        public bool Remove(TKey? key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var code = (key.GetHashCode() & 0x7FFFFFFF) % _dictionary.Length;
            var elem = _dictionary[code];
            if (elem != null)
            {
                for (int i = _dictionary[code].Count - 1; i >= 0; i--)
                {
                    var tuple = elem[i];
                    if (tuple.Item1.Equals(key))
                    {
                        elem.Remove(tuple);
                        _count--;
                        return true;
                    }
                }
            }
            return false;
        }
        public IEnumerator<(TKey, TValue)> GetEnumerator()
        {
            if (_count == 0)
            {
                throw new Exception("You cannot enumerate an empty list");
            }
            for (int i = 0; i < _dictionary.Length; i++)
            {
                var list = _dictionary[i];
                foreach (var elem in list)
                {
                    yield return elem;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
