namespace PROXY_PATTERN;

public static class Helper
{
    public static List<object> GetLargeData()
    {
        var list = new List<object>();

        for (int i = 0; i < 1000; i++)
        {
            list.Add(new
            {
                id = i + 1,
                name = $"name-${i + 1}"
            });
        }

        Console.WriteLine("Large data created");

        return list;
    }

    public static void Log(string message)
    {
        Console.WriteLine(message);
    }
}
