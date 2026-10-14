using System.Collections;

namespace List
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, int>();
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.AddRange(new List<int>(){1, 2, 3});
            Console.WriteLine(String.Join(", ", list));
            list.RemoveAt(0);
            Console.WriteLine(String.Join(", ", list));
            list.Remove(0);
            Console.WriteLine(String.Join(", ", list));
            list.Remove(2);
            Console.WriteLine(String.Join(", ", list));
            list.Insert(0, 2);
            Console.WriteLine(String.Join(", ", list));
            list.Clear();
            Console.WriteLine(String.Join(", ", list));
        }
    }
    
}
