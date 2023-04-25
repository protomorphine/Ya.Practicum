namespace Ya.Practicum.SprintOne;

public static class LLetter
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var s = reader.ReadLine()!.OrderBy(it => it).ToList();
        var t = reader.ReadLine()!.OrderBy(it => it).ToList();

        foreach (var ch in s)
            t.Remove(ch);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(t.First());
    }
}