namespace SinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new MySinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.Print();
            list.RemoveLast();
            list.Print();
            list.RemoveFirst();
            list.Print();
            list.Clear();
            list.Print();
        }
    }
}
