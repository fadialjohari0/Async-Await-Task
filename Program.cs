class Program
{
    static async Task Main(string[] args)
    {
        List<Item> items = new List<Item>
        {
            new Item("Item 1"),
            new Item("Item 2"),
            new Item("Item 3"),
            new Item("Item 4"),
            new Item("Item 5"),
        };

        var tasks = new List<Task<string>>();

        foreach (var item in items)
        {
            tasks.Add(ProcessItemAsync(item));
        }

        await Task.WhenAll(tasks);

        foreach (var task in tasks)
        {
            var result = await task;
            Console.WriteLine(result);
        }
    }

    class Item
    {
        public string Name;

        public Item(string name)
        {
            Name = name;
        }
    }

    static async Task<string> ProcessItemAsync(Item item)
    {
        await Task.Delay(1000);

        return $"Processed Item: {item.Name}";
    }
}