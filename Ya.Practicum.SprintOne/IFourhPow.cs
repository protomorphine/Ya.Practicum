namespace Ya.Practicum.SprintOne;

public static class IFourhPow
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var number = int.Parse(reader.ReadLine()!);

        var res = Math.Log(number, 4);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(Math.Truncate(res) == res ? "True" : "False");
    }
}