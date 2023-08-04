namespace Ya.Practicum.SprintSeven;

/// <summary>
/// В мире последовательностей нет гороскопов. Поэтому когда две последовательности хотят понять,
/// могут ли они счастливо жить вместе, они оценивают свою совместимость как длину
/// их наибольшей общей подпоследовательности.
/// Подпоследовательность получается из последовательности удалением некоторого (возможно, нулевого) числа элементов.
/// То есть элементы сохраняют свой относительный порядок, но не обязаны изначально идти подряд.
/// Найдите наибольшую общую подпоследовательность двух одиноких последовательностей и выведите её!
/// </summary>
public static class KHoroscopes
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var firstLength = int.Parse(reader.ReadLine()!);
        var firstSequence = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var secondLength = int.Parse(reader.ReadLine()!);
        var secondSequence = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();

        var memo = CountLength(firstSequence, secondSequence);
        Console.WriteLine(memo[firstLength - 1, secondLength - 1]);
        var subSequences = RestoreSubSequences(firstSequence, secondSequence, memo);

        if (!subSequences.Any())
            return;
        
        foreach (var index in subSequences)
            Console.WriteLine(string.Join(" ", index.OrderBy(it => it)));
    }

    private static int[,] CountLength(IReadOnlyList<int> first, IReadOnlyList<int> second)
    {
        var memo = new int[first.Count, second.Count];

        for (var i = 0; i < first.Count; i++)
        {
            for (var j = 0; j < second.Count; j++)
            {
                if (first[i] == second[j])
                {
                    var prevLongest = i - 1 >= 0 && j - 1 >= 0 ? memo[i - 1, j - 1] : 0;
                    memo[i, j] = prevLongest + 1;
                    continue;
                }

                var prevFirst = i - 1 >= 0 ? memo[i - 1, j] : 0;
                var prevSecond = j - 1 >= 0 ? memo[i, j - 1] : 0;
                memo[i, j] = Math.Max(prevFirst, prevSecond);
            }
        }

        return memo;
    }

    private static List<List<int>> RestoreSubSequences(IReadOnlyList<int> first, IReadOnlyList<int> second, int[,] memo)
    {
        var firstIndices = new List<int>();
        var secondIndices = new List<int>();

        var i = first.Count - 1;
        var j = second.Count - 1;

        while (i >= 0 && j >= 0)
        {
            if (first[i] == second[j])
            {
                firstIndices.Add(i + 1);
                secondIndices.Add(j + 1);
                i--;
                j--;
            }
            else if (i - 1 >= 0 && memo[i - 1, j] == memo[i, j])
                i--;
            else if (j - 1 >= 0 && memo[i, j - 1] == memo[i, j])
                j--;
            else
                break;
        }

        return new List<List<int>> { firstIndices, secondIndices };
    }
}