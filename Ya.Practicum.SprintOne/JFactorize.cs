using System.Diagnostics;
using Microsoft.VisualBasic;

namespace Ya.Practicum.SprintOne;

public static class JFactorize
{
    public static void Execute()
    {
        var sw = new Stopwatch();
        using var reader = new StreamReader(Console.OpenStandardInput());
        var num = int.Parse(reader.ReadLine()!);

        var res = new List<int>();
        for (var i = 2; i * i <= num; i++)
        {
            while (num % i == 0)
            {
                res.Add(i);
                num /= i;
            }
        }

        if (num > 1)
            res.Add(num);

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(string.Join(" ", res));
    }
}