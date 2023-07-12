namespace Ya.Practicum.SprintFour;

/// <summary>
/// Жители Алгосского архипелага придумали новый способ сравнения строк.
/// Две строки считаются равными, если символы одной из них можно заменить на символы другой так,
/// что первая строка станет точной копией второй строки. При этом необходимо соблюдение двух условий:
///
///     Порядок вхождения символов должен быть сохранён.
///
///     Одинаковым символам первой строки должны соответствовать одинаковые символы второй строки.
///     Разным символам —– разные.
///
/// Например, если строка s = «abacaba», то ей будет равна строка t = «xhxixhx»,
/// так как все вхождения «a» заменены на «x», «b» –— на «h», а «c» –— на «i».
/// Если же первая строка s=«abc», а вторая t=«aaa», то строки уже не будут равны,
/// так как разные буквы первой строки соответствуют одинаковым буквам второй.
/// </summary>
public static class HStrangeComparison
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var s = reader.ReadLine()!;
        var t = reader.ReadLine()!;

       Console.WriteLine(Compare(s, t));
    }

    private static string Compare(string str1, string str2)
    {
        if (str1.Length != str2.Length)
            return "NO";

        var map = new Dictionary<char, char>();
        for (var i = 0; i < str1.Length; i++)
        {
            if (map.ContainsKey(str1[i]) || map.ContainsValue(str2[i]))
                continue;
            map.Add(str1[i], str2[i]);
        }

        for (var i = 0; i < str1.Length; i++)
        {
            if (!map.TryGetValue(str1[i], out var value))
                return "NO";

            if (value != str2[i])
                return "NO";
        }

        return "YES";
    }
}