namespace Ya.Practicum.SprintOne;

public static class DWeatherForecast
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var len = int.Parse(reader.ReadLine()!);
        var temps = reader.ReadLine()!
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        temps.Insert(0, -273);
        temps.Add(-273);

        var res = 0;
        for (var i = 1; i < temps.Count - 1; i++)
        {
            if (temps[i] > temps[i - 1] && temps[i] > temps[i + 1])
                res += 1;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(res);
    }
}