using SinglyLinkedList;
using System;
using List;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class ListTest
    {
        [Test]
        public void Add_AddToFullList_ExpandList()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 2 3 4 5 ";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Add_AddToNormalList_ExpandList()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 2 3 4 ";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Print_EmptyList_EmptyString()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "";
            //act
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Print_NotEmptyList_StringOfElements()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 2 3 4 ";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Remove_NonexistentElement_UnchangedArray()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 2 3 4 ";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Remove(5);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Remove_ExistingElement_ShrinkedArray()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 2 3 ";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Remove(4);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void RemoveAt_EmptyList_EmptyString()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "";
            //act
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void RemoveAt_NormalList_StringOfElements()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 3 4 ";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.RemoveAt(1);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Clear_NormalList_EmptyString()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Clear();
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddRange_EmptyRange_UnchangedList()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "";
            //act
            list.AddRange(new int[0]);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void AddRange_Normal_ExpandedList()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 2 3 4 5 ";
            //act
            list.AddRange(new int[5]{1, 2, 3, 4, 5});
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Insert_ExistingIndexFullArray_ExpandedList()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 2 3 4 5 ";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(5);
            list.Insert(2, 3);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Insert_ExistingIndexNotFullArray_ExpandedList()
        {
            //arrange
            var list = new MyList<int>();
            var expectedRes = "1 2 3 4 ";
            //act
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Insert(2, 3);
            var actualRes = list.Print();
            //assert
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }

    }
}
