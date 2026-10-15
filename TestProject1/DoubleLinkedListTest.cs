using System;
using System.Collections.Generic;
using System.Text;
using DoubleLinkedCycledListWithATail;
namespace TestProject1
{
    public class DoubleLinkedListTest
    {
        [Test]
        public void Print_EmptyList_EmptyString()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = string.Empty;
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void Print_List_AllElements()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = "2 3 5 ";
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(5);
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void Find_ExistingValue_Value()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = 5;
            list.AddLast(5);
            var actualRes = list.Find(5).Value;
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void Find_NonExistentValue_Null()
        {
            var list = new MyDoubleLinkedList<int>();
            object expectedRes = null;
            list.AddLast(3);
            var actualRes = list.Find(5);
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void FindLast_NonExistentValue_Null()
        {
            var list = new MyDoubleLinkedList<int>();
            object expectedRes = null;
            list.AddLast(3);
            list.AddLast(7);
            var actualRes = list.FindLast(5);
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void FindLast_ExistingValue_Value()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = 7;
            list.AddLast(5);
            list.AddLast(3);
            list.AddLast(7);
            var actualRes = list.FindLast(7).Value;
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void AddFirst_EmptyList_HeadEqualsTail()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = true;
            list.AddFirst(5);
            var actualRes = (list.Head.Value == 5 && list.Tail.Value == 5);
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void AddFirst_List_Elems()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = "5 4 3 ";
            list.AddFirst(3);
            list.AddFirst(4);
            list.AddFirst(5);
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void AddLast_EmptyList_HeadEqualsTail()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = true;
            list.AddLast(3);
            var actualRes = (list.Tail.Value == 3 && list.Head.Value == 3);
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void AddLast_List_Elems()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = "1 2 3 ";
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void AddBefore_List_Elems()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = "1 2 5 3 ";
            var node = new Node<int>(5);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddBefore(list.Find(3), node);
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void AddBefore_NullNode_Unchanged()
        {
            var list = new MyDoubleLinkedList<string>();
            var expectedRes = "1 2 3 ";
            Node<string> node = null;
            list.AddLast("1");
            list.AddLast("2");
            list.AddLast("3");
            list.AddBefore(list.Find("3"), node);
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void AddAfter_NullNode_Unchanged()
        {
            var list = new MyDoubleLinkedList<string>();
            var expectedRes = "1 2 3 ";
            Node<string> node = null;
            list.AddLast("1");
            list.AddLast("2");
            list.AddLast("3");
            list.AddAfter(list.Find("3"), node);
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void AddAfter_List_Elems()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = "1 2 5 3 ";
            var node = new Node<int>(5);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddAfter(list.Find(2), node);
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void Remove_List_Elems()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = "1 3 ";
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.Remove(list.Find(2));
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void Remove_NullNode_Elems()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = "1 2 3 ";
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.Remove(list.Find(5));
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void Remove_Head_Elems()
        {
            var list = new MyDoubleLinkedList<int>();
            var expectedRes = string.Empty;
            list.AddLast(1);
            list.Remove(list.Head);
            var actualRes = list.Print();
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [Test]
        public void RemoveFirst_EmptyList_PrintEmpty()
        {
            var list = new MyDoubleLinkedList<int>();

            list.RemoveFirst();

            Assert.That(list.Print(), Is.EqualTo(string.Empty));
        }
        [Test]
        public void RemoveFirst_ManyElements_PrintRemaining()
        {
            var list = new MyDoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.RemoveFirst();

            Assert.That(list.Print(), Is.EqualTo("2 3 "));
        }
        [Test]
        public void RemoveFirst_MoreThanCount_PrintEmpty()
        {
            var list = new MyDoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.RemoveFirst();
            list.RemoveFirst();
            list.RemoveFirst();

            Assert.That(list.Print(), Is.EqualTo(string.Empty));
        }
        [Test]
        public void RemoveLast_EmptyList_PrintEmpty()
        {
            var list = new MyDoubleLinkedList<int>();

            list.RemoveLast();

            Assert.That(list.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void RemoveLast_ManyElements_PrintRemaining()
        {
            var list = new MyDoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            list.RemoveLast();

            Assert.That(list.Print(), Is.EqualTo("1 2 "));
        }
        [Test]
        public void RemoveLast_MoreThanCount_PrintEmpty()
        {
            var list = new MyDoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.RemoveLast();
            list.RemoveLast();
            list.RemoveLast();
            Assert.That(list.Print(), Is.EqualTo(string.Empty));
        }
    }
}
