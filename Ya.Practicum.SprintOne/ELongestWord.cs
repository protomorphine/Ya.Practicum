namespace Ya.Practicum.SprintOne;

public static class ELongestWord
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var length = int.Parse(reader.ReadLine()!);
        var text = reader.ReadLine()!;

        var res = text.Split(' ').OrderByDescending(it => it.Length).First();

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(res);
        writer.WriteLine(res.Length);
    }
}