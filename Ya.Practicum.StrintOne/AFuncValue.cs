namespace Ya.Practicum.StrintOne;

public static class AFuncValue
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var line = reader.ReadLine()!
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var res = line[0] * line[1] * line[1] + line[2] * line[1] + line[3];

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(res);
    }
}