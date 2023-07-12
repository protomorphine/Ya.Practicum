namespace Ya.Practicum.SprintThree;

/// <summary>
/// Гоша любит играть в игру «Подпоследовательность»:
/// даны 2 строки, и нужно понять, является ли первая из них подпоследовательностью второй.
/// Когда строки достаточно длинные, очень трудно получить ответ на этот вопрос, просто посмотрев на них.
/// Помогите Гоше написать функцию, которая решает эту задачу.
/// </summary>
public static class CSubsequence
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine(reader.ReadLine()!.IsSubsequenceOf(reader.ReadLine()!));
    }

    private static bool IsSubsequenceOf(this string a, string b)
    {
        if (a.Length > b.Length)
            return false;

        var neededLength = a.Length;
        var firstPointer = 0;
        var secondPointer = 0;

        while (neededLength > 0)
        {
            if (firstPointer > a.Length - 1 || secondPointer > b.Length - 1)
                return false;

            if (a[firstPointer] == b[secondPointer])
            {
                neededLength--;
                firstPointer++;
                secondPointer++;
                continue;
            }

            secondPointer++;

            if (secondPointer == b.Length - 1)
                break;
        }

        return neededLength == 0;
    }
}
