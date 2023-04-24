namespace Ya.Practicum.StrintOne;

public static class HBinarySum
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var first = reader.ReadLine()!.Select(i => (int)i - '0').ToList();
        var second = reader.ReadLine()!.Select(i => (int)i - '0').ToList();

        var res = "";
        var over = 0;
        
        for (int i = first.Count - 1; i >= 0; i--)
        {
            var tmp = first[i] + second[i] + over;
            if (tmp == 2)
            {
                res += '0';
                over = 1;
                continue;
            }

            res += '1';
            over = 0;
        }

        if (over != 0)
            res += over;

        var reversed = res.ToCharArray();
        Array.Reverse(reversed);
        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(new string(reversed));
    }
}