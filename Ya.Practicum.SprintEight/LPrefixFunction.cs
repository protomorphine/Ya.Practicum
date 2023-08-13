namespace Ya.Practicum.SprintEight;

/// <summary>
/// В этой задаче вам необходимо посчитать префикс-функцию для заданной строки.
/// </summary>
public static class LPrefixFunction
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var str = reader.ReadLine()!;

        var prefix = new int[str.Length];
        for (var i = 1; i < str.Length; i++)
        {
            var k = prefix[i - 1];

            while (k != 0 && str[k] != str[i]) 
                k = prefix[k - 1];

            prefix[i] = str[k] == str[i] ? k + 1 : 0;
        }
        
        Console.WriteLine(string.Join(' ', prefix));
    }
}