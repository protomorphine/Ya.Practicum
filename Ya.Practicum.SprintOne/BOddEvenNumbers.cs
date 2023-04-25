namespace Ya.Practicum.SprintOne;

public static class BOddEvenNumbers
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());

        var line = reader.ReadLine()!
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => Math.Abs(int.Parse(s) % 2))
            .ToList();

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(line.All(i => i is 0) || line.All(i => i is 1) ? "WIN" : "FAIL");
    }
}
