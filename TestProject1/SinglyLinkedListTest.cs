
using NUnit.Framework;
using SinglyLinkedList;
namespace SinglyLinkedListTest
{
    public class SinglyLinkedListTest
    {
        [Test]
        public void Print_Empty_EmptyString()
        {
            //arrange
            var emptyList = new MySinglyLinkedList<int>();
            var expectedRes = "";
            //act
            var actualRes = emptyList.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Print_NotEmpty_SpacedOutString()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(5);
            var expectedRes = "5 1 ";
            //act
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddFirst_EmptyList_AddHead()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "1 ";
            //act
            list.AddFirst(1);
            var actualRes = list.Print();
            //assert
            NUnit.Framework.Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddFirst_List_SwitchHead()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "2 5 3 ";
            //act
            list.AddFirst(3);
            list.AddFirst(5);
            list.AddFirst(2);
            var actualRes = list.Print();
            //assert
            NUnit.Framework.Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddLast_EmptyList_AddHead()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "1 ";
            //act
            list.AddFirst(1);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddLast_List_ElemToEnd()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "1 2 3 ";
            //act
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddBefore_Normal_AddBefore()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "1 3 2 ";
            //act
            list.AddLast(1);
            var node = list.AddLast(2);
            list.AddBefore(node, 3);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddAfter_Normal_AddAfter()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "1 2 4 3 ";
            //act
            list.AddLast(1);
            var node = list.AddLast(2);
            list.AddLast(3);
            list.AddAfter(node, 4);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Remove_Empty_NoAction()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "";
            //act
            list.Remove(1);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Remove_HeadRemoved_Empty()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "";
            //act
            list.AddFirst(1);
            list.Remove(1);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Remove_ElementRemoved_ListWithoutElement()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "1 3 4 ";
            //act
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.Remove(2);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void RemoveFirst_OnlyHead_EmptyList()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "";
            //act
            list.AddFirst(1);
            list.RemoveFirst();
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void RemoveFirst_FirstElem_ListWithoutFirstElem ()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "2 3 4 ";
            //act
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.RemoveFirst();
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void RemoveLast_OnlyHead_EmptyList()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "";
            //act
            list.AddFirst(1);
            list.RemoveLast();
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void RemoveLast_LastElem_EmptyList()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "1 2 3 ";
            //act
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.RemoveLast();
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Clear_List_EmptyList()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var expectedRes = "";
            //act
            list.Clear();
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
    }
}
