namespace Ya.Practicum.SprintOne.Finals;

public static class BGoldenHand
{
    public static void Execute()
    {
        const int rowsCount = 4;
        const int playersCount = 2;
        const int times = 10;

        using var reader = new StreamReader(Console.OpenStandardInput());
        var k = int.Parse(reader.ReadLine()!);

        var map = new Dictionary<int, int>();
        for (var i = 0; i < rowsCount; i++)
        {
            foreach (var c in reader.ReadLine()!.ToCharArray())
            {
                if (!int.TryParse(c.ToString(), out var parsed)) continue;
                if (map.TryGetValue(parsed, out _))
                {
                    map[parsed]++;
                    continue;
                }

                map.Add(parsed, 1);
            }
        }

        var points = 0;
        for (var t = 1; t < times; t++)
        {
            var entriesCount = map.GetValueOrDefault(t);
            if (entriesCount > 0 && entriesCount <= k * playersCount)
                points++;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(points);
    }
}