using System.Text;

namespace Ya.Practicum.SprintEight.Finals;

/// <summary>
/// Вам даны строки в запакованном виде. Определим запакованную строку (ЗС) рекурсивно. Строка, состоящая только
/// из строчных букв английского алфавита является ЗС. Если A и B —– корректные ЗС, то и AB является ЗС.
/// Если A —– ЗС, а n — однозначное натуральное число, то n[A] тоже ЗС. При этом запись n[A] означает,
/// что при распаковке строка A записывается подряд n раз.
/// Найдите наибольший общий префикс распакованных строк и выведите его (в распакованном виде).
/// </summary>
public static class APackedPrefix
{
    public static void Execute()
    {
        var prefix = string.Empty;

        using var reader = new StreamReader(Console.OpenStandardInput());
        var stringsCount = int.Parse(reader.ReadLine()!);
        
        for (var i = 0; i < stringsCount; i++)
        {
            var unpacked = Unpack(reader.ReadLine()!);
            prefix = unpacked[..GetNewPrefixLastIndex(prefix, unpacked)];
        }

        Console.WriteLine(prefix);
    }

    private static int GetNewPrefixLastIndex(string lastPrefix, string unpacked)
    {
        if (string.IsNullOrWhiteSpace(lastPrefix))
            return unpacked.Length;

        var len = 0;

        for (var i = 0; i < unpacked.Length; i++)
        {
            if (i < lastPrefix.Length && lastPrefix[i] == unpacked[i])
            {
                len++;
                continue;
            }

            break;
        }

        return len;
    }

    private static string Unpack(string input)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < input.Length; i++)
        {
            if (char.IsNumber(input[i]))
            {
                var endBracketIdx = GetPatternLength(input, i + 1);

                MultiplyString(
                    int.Parse(input[i].ToString()),
                    Unpack(input[(i + 1)..(endBracketIdx + 1)]),
                    sb);
                i = endBracketIdx;
            }
            else if (input[i] is not '[' and not ']')
                sb.Append(input[i]);
        }

        return sb.ToString();
    }

    private static int GetPatternLength(string line, int startIdx)
    {
        var stack = new Stack<char>();

        for (var i = startIdx; i < line.Length; i++)
        {
            switch (line[i])
            {
                case '[':
                    stack.Push(line[i]);
                    break;

                case ']':
                {
                    stack.Pop();

                    if (stack.Count is 0)
                        return i;

                    break;
                }
            }
        }

        return line.Length;
    }

    private static void MultiplyString(int count, string str, StringBuilder sb)
    {
        for (var i = 0; i < count; i++)
            sb.Append(str);
    }
}