namespace Ya.Practicum.SprintEight;

/// <summary>
/// Гоша измерял температуру воздуха n дней подряд. В результате у него получился некоторый временной ряд.
/// Теперь он хочет посмотреть, как часто встречается некоторый шаблон в получившейся последовательности.
/// Однако температура — вещь относительная, поэтому Гоша решил, что при поиске шаблона длины m (a1, a2, ..., am)
/// стоит также рассматривать сдвинутые на константу вхождения. Это значит, что если для некоторого числа c в исходной
/// последовательности нашёлся участок вида (a1 + c, a2 + c, ... , am + c), то он тоже считается
/// вхождением шаблона (a1, a2, ..., am).
/// По заданной последовательности измерений X и шаблону A=(a1, a2, ..., am) определите все вхождения A в X,
/// допускающие сдвиг на константу.
/// Подсказка: если вы пишете на питоне и сталкиваетесь с TL, то попробуйте заменить какие-то
/// из циклов операциями со срезами.
/// </summary>
public static class GShiftSearch
{
    public static void Execute()
    {
        using var reader = new StreamReader(Console.OpenStandardInput());
        var measurementCount = int.Parse(reader.ReadLine()!);
        var measurements = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();

        var m = int.Parse(reader.ReadLine()!);
        var pattern = reader.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        
        Console.WriteLine(string.Join(' ', Search(measurements, pattern).Select(i => i + 1)));
    }

    private static IEnumerable<int> Search(IReadOnlyList<int> input, IReadOnlyList<int> pattern)
    {
        if (pattern.Count > input.Count)
            return Enumerable.Empty<int>();

        var result = new List<int>();

        for (var pos = 0; pos <= input.Count - pattern.Count; pos++)
        {
            var shift = input[pos] - pattern[0];

            var isMatch = pattern
                .Select((t, offset) => input[pos + offset] - t)
                .All(newShift => newShift == shift);

            if (isMatch)
                result.Add(pos);
        }

        return result;
    }
}