namespace Ya.Practicum.SprintOne;

/// <summary>
/// Помогите Васе понять, будет ли фраза палиндромом.
/// Учитываются только буквы и цифры, заглавные и строчные буквы считаются одинаковыми.
/// <br />Решение должно работать за O(N), где N — длина строки на входе.
/// </summary>
public static class FPalindrome
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var text = reader.ReadLine()!;
        text = new string(text.ToLower().Where(char.IsLetterOrDigit).ToArray());

        var lp = 0;
        var rp = text.Length - 1;
        var isPalindrome = true;
        while (lp != text.Length / 2)
        {
            if (text[lp] == text[rp])
            {
                lp++;
                rp--;
                continue;
            }

            isPalindrome = false;
            break;
        }

        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(isPalindrome);
    }
}