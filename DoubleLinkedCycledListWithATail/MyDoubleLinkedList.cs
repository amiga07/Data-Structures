using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DoubleLinkedCycledListWithATail
{
    public class MyDoubleLinkedList<T>
    {
        public Node<T> Head { get; set; } = null;
        public Node<T> Tail { get; set; } = null;
        private int _count { get; set; } = 0;
        public string Print()
        {
            if (Head == null) return string.Empty;
            if (Head.Next == null) return Head.Value + "";

            string result = Head.Value + " ";
            Node<T> current = Head.Next;
            while (current != Head)
            {
                result += current.Value + " ";
                current = current.Next;
            }
            return result;
        }
        public Node<T> Find(T value)
        {
            if (_count == 1)
            {
                return Head.Value.Equals(value) ? Head : null;
            }
            var count = 0;
            var elem = Head;
            while (count != _count)
            {
                if (elem.Value.Equals(value)) return elem;
                elem = elem.Next;
                count++;
            }
            return null;
        }
        public Node<T> FindLast(T value)
        {
            if (_count == 1)
            {
                return Tail.Value.Equals(value) ? Tail : null;
            }
            var count = 0;
            var elem = Tail;
            while (count != _count)
            {
                if (elem.Value.Equals(value)) return elem;
                count++;
                elem = elem.Previous;
            }
            return null;
        }
        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            if (_count == 0)
            {
                Head = Tail = newNode;
                Head.Previous = newNode;
                Tail.Next = newNode;
                newNode.Previous = Tail;
                newNode.Next = Head;
            }
            else
            {
                newNode.Next = Head;
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Head.Previous = newNode;
                Head = newNode;
            }
            _count++;
        }
        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);
            if (_count == 0)
            {
                Head = Tail = newNode;
                Head.Previous = newNode;
                Tail.Next = newNode;
                newNode.Previous = Tail;
                newNode.Next = Head;
            }
            else
            {
                newNode.Next = Head;
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Head.Previous = newNode;
                Tail = newNode;
            }
            _count++;
        }
        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (node == null || newNode == null) return;
            if (node == Head)
            {
                AddFirst(newNode.Value);
                return;
            }
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
            _count++;
        }
        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (node == null || newNode == null) return;
            if (node == Tail)
            {
                AddLast(newNode.Value);
                return;
            }
            newNode.Next = node.Next;
            newNode.Previous = node;
            node.Next.Previous = newNode;
            node.Next = newNode;
            _count++;
        }
        public void Remove(Node<T> node)
        {
            if (node == null) return;
            if (node == Head && node == Tail)
            {
                Head = Tail = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                if (node == Head)
                {
                    Head = node.Next;
                }
                if (node == Tail)
                {
                    Tail = node.Previous;
                }
            }
            _count--;
        }
        public void RemoveFirst()
        {
            if (_count == 0) return;
            if (_count == 1)
            {
                Head = Tail = null;
                return;
            }
            var head = Head;
            Head.Next.Previous = Tail;
            Tail.Next = Head.Next;
            Head = Head.Next;
            head.Next = null;
            head.Previous = null;
            _count--;
        }
        public void RemoveLast()
        {
            if (_count == 0) return;
            if (_count == 1)
            {
                Head = Tail = null;
                return;
            }
            var tail = Tail;
            Tail.Previous.Next = Head;
            Head.Previous = Tail.Previous;
            Tail = Tail.Previous;
            tail.Next = null;
            tail.Previous = null;
            _count--;
        }
    }
}

