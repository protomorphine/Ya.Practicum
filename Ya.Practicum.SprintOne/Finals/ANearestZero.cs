namespace Ya.Practicum.SprintOne.Finals;

public static class ANearestZero
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var len = int.Parse(reader.ReadLine()!);
        var street = reader.ReadLine()!
            .Split(new[] {' ', '\t',}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();

        var result = new List<int>();
        var distance = len;

        foreach (var house in street)
        {
            distance = house == 0 ? 0 : ++distance;
            result.Add(distance);
        }
        
        distance = len;
        for (var i = len - 1; i >= 0; i--)
        {
            distance = street[i] == 0 ? 0 : ++distance;
            var minDistance = Math.Min(distance, result[i]);
            result[i] = minDistance;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(string.Join(" ", result));
    }
}