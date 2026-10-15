using Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class QueueTest
    {
        [Test]
        public void Print_EmptyQueue_EmptyString()
        {
            var queue = new MyQueue<int>();

            Assert.That(queue.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Print_AfterPushes_AllElementsInOrder()
        {
            var queue = new MyQueue<int>();
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            Assert.That(queue.Print(), Is.EqualTo("1 2 3 "));
        }

        [Test]
        public void Empty_NewQueue_True()
        {
            var queue = new MyQueue<int>();

            Assert.That(queue.Empty(), Is.True);
        }

        [Test]
        public void Empty_AfterPush_False()
        {
            var queue = new MyQueue<int>();
            queue.Push(1);

            Assert.That(queue.Empty(), Is.False);
        }
        [Test]
        public void Push_SingleItem_PrintShowsIt()
        {
            var queue = new MyQueue<int>();
            queue.Push(42);

            Assert.That(queue.Print(), Is.EqualTo("42 "));
        }

        [Test]
        public void Push_ManyItems_PrintShowsAllInOrder()
        {
            var queue = new MyQueue<int>();
            for (int i = 1; i <= 5; i++)
            {
                queue.Push(i);
            }

            Assert.That(queue.Print(), Is.EqualTo("1 2 3 4 5 "));
        }

        [Test]
        public void Pop_SingleItem_ReturnsItAndQueueBecomesEmpty()
        {
            var queue = new MyQueue<int>();
            queue.Push(10);

            var result = queue.Pop();

            Assert.That(result, Is.EqualTo(10));
            Assert.That(queue.Empty(), Is.True);
            Assert.That(queue.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Pop_MultipleItems_ReturnsFirstInFirst()
        {
            var queue = new MyQueue<int>();
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            Assert.That(queue.Pop(), Is.EqualTo(1));
            Assert.That(queue.Pop(), Is.EqualTo(2));
            Assert.That(queue.Pop(), Is.EqualTo(3));
            Assert.That(queue.Empty(), Is.True);
        }

        [Test]
        public void Pop_EmptyQueue_Throws()
        {
            var queue = new MyQueue<int>();

            Assert.Throws<Exception>(() => queue.Pop());
        }
        [Test]
        public void Peek_ReturnsFirstWithoutRemoving()
        {
            var queue = new MyQueue<int>();
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            Assert.That(queue.Peek(), Is.EqualTo(1));
            Assert.That(queue.Peek(), Is.EqualTo(1));
            Assert.That(queue.Print(), Is.EqualTo("1 2 3 "));
        }

        [Test]
        public void Peek_EmptyQueue_Throws()
        {
            var queue = new MyQueue<int>();

            Assert.Throws<Exception>(() => queue.Peek());
        }
        [Test]
        public void Clear_EmptyQueue_StaysEmpty()
        {
            var queue = new MyQueue<int>();

            queue.Clear();

            Assert.That(queue.Empty(), Is.True);
            Assert.That(queue.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Clear_AfterPushes_QueueBecomesEmpty()
        {
            var queue = new MyQueue<int>();
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            queue.Clear();

            Assert.That(queue.Empty(), Is.True);
            Assert.That(queue.Print(), Is.EqualTo(string.Empty));
        }
    }
}
