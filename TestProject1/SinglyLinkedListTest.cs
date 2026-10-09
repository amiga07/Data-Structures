
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
            NUnit.Framework.Assert.That(actualRes, Is.EqualTo(expectedRes));
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
            NUnit.Framework.Assert.That(actualRes, Is.EqualTo(expectedRes));
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
            NUnit.Framework.Assert.That(actualRes, Is.EqualTo(expectedRes));
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
            NUnit.Framework.Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
    }
}
