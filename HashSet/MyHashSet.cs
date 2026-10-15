using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    public class MyHashSet<T>
    {
        public List<T> Items { get; }
        public MyHashSet()
        {
            Items = new List<T>();
        }
        public string Print()
        {
            var res = "";
            foreach (var item in Items)
            {
                res += item + " ";
            }
            return res;
        }
        public bool Empty()
        {
            return Items.Count == 0;
        }
        public bool Add(T elem)
        {
            if (Items.Contains(elem)) return false;
            Items.Add(elem);
            return true;
        }
        public bool Remove(T elem)
        {
            return Items.Remove(elem);
        }
        public void Union(MyHashSet<T> other)
        {
            if (other == null)
            {
                throw new Exception("Множество не должно быть пустым");
            }
            foreach (var elem in other.Items)
            {
                if (!Items.Contains(elem)) Items.Add(elem);
            }
        }
        public void Intersect(MyHashSet<T> other)
        {
            if (other == null)
            {
                throw new Exception("Множество не должно быть пустым");
            }
            for (int i = 0; i < Items.Count; i++)
            {
                var elem = Items[i];
                if (!other.Items.Contains(elem))
                {
                    Items.Remove(elem);
                    i--;
                }
            }
        }
        public void Difference(MyHashSet<T> other)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var elem = Items[i];
                if (other.Items.Contains(elem))
                {
                    Items.Remove(elem);
                    i--;
                }
            }
        }
        public bool IsSubset(MyHashSet<T> otherSet)
        {
            var count = 0;
            foreach (var elem in Items)
            {
                if (otherSet.Items.Contains(elem)) count++;
            }
            return count == Items.Count;
        }
    }
}
