using System.Net;

namespace Ya.Practicum.SprintOne;

public static class FPalindrome
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var text = reader.ReadLine()!;
        text = new string(text.ToLower().Where(char.IsLetterOrDigit).ToArray());

        var lp = 0;
        var rp = text.Length - 1;
        var res = "True";
        while (lp != text.Length / 2)
        {
            if (text[lp] == text[rp])
            {
                res = "True";
                lp++;
                rp--;
                continue;
            }

            res = "False";
            break;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(res);
    }
}