
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
            var expectedRes = list.Head.Value == 1;
            //act
            list.AddFirst(1);
            var actualRes = list.Head.Value;
            //assert
            NUnit.Framework.Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddFirst_List_SwitchHead()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            var head = list.Head.Value;
            var expectedRes = list.Head.Next.Value == head;
            //act
            list.AddFirst(1);
            list.AddFirst(5);
            var actualRes = list.Head.Next.Value;
            //assert
            NUnit.Framework.Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
    }
}
