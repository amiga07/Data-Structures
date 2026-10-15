using Stack;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class StackTest
    {
        [Test]
        public void Print_EmptyStack_EmptyString()
        {
            var stack = new MyStack<int>();

            Assert.That(stack.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Print_AfterPushes_AllElementsInOrder()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.That(stack.Print(), Is.EqualTo("1 2 3 "));
        }

        [Test]
        public void Empty_NewStack_True()
        {
            var stack = new MyStack<int>();

            Assert.That(stack.Empty(), Is.True);
        }

        [Test]
        public void Empty_AfterPush_False()
        {
            var stack = new MyStack<int>();
            stack.Push(1);

            Assert.That(stack.Empty(), Is.False);
        }

        [Test]
        public void Push_ManyItems_PrintShowsAllInOrder()
        {
            var stack = new MyStack<int>();
            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
            }

            Assert.That(stack.Print(), Is.EqualTo("1 2 3 4 5 "));
        }
        [Test]
        public void Pop_SingleItem_ReturnsItAndStackBecomesEmpty()
        {
            var stack = new MyStack<int>();
            stack.Push(10);

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo(10));
            Assert.That(stack.Empty(), Is.True);
            Assert.That(stack.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Pop_MultipleItems_ReturnsLastInFirst()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.That(stack.Pop(), Is.EqualTo(3));
            Assert.That(stack.Pop(), Is.EqualTo(2));
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.Empty(), Is.True);
        }

        [Test]
        public void Pop_EmptyStack_Throws()
        {
            var stack = new MyStack<int>();

            Assert.Throws<Exception>(() => stack.Pop());
        }
        [Test]
        public void Peek_EmptyStack_Throws()
        {
            var stack = new MyStack<int>();

            Assert.Throws<Exception>(() => stack.Peek());
        }

        [Test]
        public void Peek_AfterPop_ReturnsNewTop()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();

            Assert.That(stack.Peek(), Is.EqualTo(1));
        }
        [Test]
        public void Clear_EmptyStack_StaysEmpty()
        {
            var stack = new MyStack<int>();

            stack.Clear();

            Assert.That(stack.Empty(), Is.True);
            Assert.That(stack.Print(), Is.EqualTo(string.Empty));
        }
    }
}
