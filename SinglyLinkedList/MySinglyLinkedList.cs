using System;
using System.Collections.Generic;
using System.Text;

namespace SinglyLinkedList
{
    public class MySinglyLinkedList<T>
    {
        private Node<T> Head;
        private int count = 0;

        public string Print()
        {
            var res = "";
            if (count != 0)
            {
                var current = Head;
                while (current != null)
                {
                    res += current.Value + " ";
                    current = current.Next;
                };
            }
            return res;
        }
        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);
            if (count != 0)
            {
                newNode.Next = Head;
            }
            Head = newNode;
            count++;
        }
        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);
            if (count == 0)
            {
                Head = newNode;
                count++;
                return;
            }
            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Next = null;
            count++;
        }
        public void AddBefore(Node<T> node, T item)
        {
            var newNode = new Node<T>(item);
            Node<T> previous = null;
            var current = Head;
            while (current.Next != null)
            {
                if (current.Next == node)
                {
                    previous = current;
                    break;
                }
                current = current.Next;
            }
            previous.Next = newNode;
            newNode.Next = node;
            count++;
        }
        public void AddAfter(Node<T> node, T item)
        {
            var newNode = new Node<T>(item);
            newNode.Next = node.Next;
            node.Next = newNode;
            count++;
        }
        public bool Remove(T value)
        {
            if (count == 0) return false;
            if (Head.Value.Equals(value))
            {
                Head = Head.Next;
                count--;
                return true;
            }
            var current = Head;
            while (current.Next != null)
            {
                if (current.Next.Value.Equals(value))
                {
                    current.Next = current.Next.Next;
                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public void RemoveFirst()
        {
            if (count == 1) Head = null;
            Head = Head.Next;
            count--;
        }
        public void RemoveLast()
        {
            if (count == 1) Head = null;
            var current = Head;
            while (current != null)
            {
                if (current.Next.Next == null)
                {
                    current.Next = null;
                    count--;
                    return;
                }
                current = current.Next;
            }
        }
        public void Clear()
        {
            Head = null;
            count = 0;
        }
    }
}
