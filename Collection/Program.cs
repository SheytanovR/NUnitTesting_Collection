namespace Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new Collection<int>();
            Console.WriteLine($"Collection: {collection.ToString()}");

            Console.WriteLine($"Collection count: {collection.Count}");

            Console.WriteLine($"Collection capacity: {collection.Capacity}");

            collection.Add(5);
            Console.WriteLine(collection.Count);
            collection.AddRange(4, 5);
            Console.WriteLine(collection.ToString());
            Console.WriteLine(collection.Count);
            Console.WriteLine($"Print the first element: {collection[0]}");
            collection.InsertAt(3, 6);
            Console.WriteLine(collection.ToString());
            collection.Exchange(3,2);
            Console.WriteLine(collection.ToString());
            collection.RemoveAt(3);
            Console.WriteLine(collection.ToString());
        }
    }
}
